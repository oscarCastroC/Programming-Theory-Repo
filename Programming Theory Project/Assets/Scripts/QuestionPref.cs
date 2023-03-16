using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//**************************************************************************************************************************************************************//
//********                                                                                                                                              ********//
//********              #####  ##     #####  #####   ####    ####   ####    ##   #####    #####    ###   ######  #####                                  ********//
//********              ##     ##     ##     ##     ##   #    ##   ##  ##   ##  ##       ##       ## ##    ##    ##                                     ********//
//********              #####  ##     #####  #####  #####     ##   ##   ##  ##  ##  ##   ##      #######   ##    #####                                  ********//
//********                 ##  ##     ##     ##     ##        ##   ##    ## ##  ##   ##  ##      ##   ##   ##       ##                                  ********//
//********              #####  #####  #####  #####  ##       ####  ##      ###   #####    #####  ##   ##   ##    #####                                  ********//
//********                                                                                                                                              ********//
//**************************************************************************************************************************************************************//
//**************************************************************************************************************************************************************//
//********                     Creator: Oscar Castronuņo                       Date: 03-16-2023                                                         ********//
//**************************************************************************************************************************************************************//
//**************************************************************************************************************************************************************//
//**    MODIFICATION    DATE            NAME        DESCRIPTION                                                                                                 //
//**    ------------    -----------    ---------   -------------------------------------------------------------------------------------------------------------//
//**       + xx         xx-xx-xxxx      OSCAR.CC    XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX      //
//**************************************************************************************************************************************************************//

public class QuestionPref : MonoBehaviour
{
    [SerializeField] private int questionNumber;
    [SerializeField] private TextMeshProUGUI questionTxt;
    [SerializeField] private TextMeshProUGUI numATxt;
    [SerializeField] private TextMeshProUGUI numBTxt;
    private repeatGround repeatGroundObj;
    private bool isNumA;                                    // isNumA = true (A correct), isNumA = false (B correct)
    private int nivel = 0;                                  // ojo cambiar por la persistente

    void Start()
    {
        repeatGroundObj = GameObject.Find("Ground").GetComponent<repeatGround>();
        CreateQuestion();
    }

    public void CreateQuestion()
    {
        int firstNum;
        int secondtNum;
        int multiNumber = 1;
        float randomResult = 0;
        float result = 0;

        //ojo getlevl
        // nivel = getlvl;
        while (nivel > 4)
        {   // 0: +, 1: -, 2: *, 3:/, 4: all
            if (nivel > 10)
            {
                nivel = nivel - 10;
                multiNumber = multiNumber + 20;
            }
            else
                nivel = nivel - 5;
        }

        if (nivel == 4)
            nivel = Random.Range(0, 4);

        firstNum = Random.Range(-100, 101) * multiNumber;
        secondtNum = Random.Range(-100, 101) * multiNumber;

        switch (nivel)
        {
            case 0:
                questionTxt.text = firstNum + " + " + secondtNum + " = ?";
                result = firstNum + secondtNum;
                break;
            case 1:
                questionTxt.text = firstNum + " - " + secondtNum + " = ?";
                result = firstNum - secondtNum;
                break;
            case 2:
                questionTxt.text = firstNum + " x " + secondtNum + " = ?";
                result = firstNum * secondtNum;
                break;
            case 3:
                questionTxt.text = firstNum + " / " + secondtNum + " = ?";
                result = firstNum / secondtNum;
                break;
        }

        if (Random.Range(0,2) == 0)
            randomResult = result + Random.Range(2, 10);
        else
            randomResult = result - Random.Range(2, 10);

        if (Random.Range(0,2) == 0)
        {
            isNumA = true;
            numATxt.text = "" + result;
            numBTxt.text = "" + randomResult;
        }
        else
        {
            isNumA = false;
            numATxt.text = "" + randomResult;
            numBTxt.text = "" + result;
        }

    }

    public void GetAnswerQ(string answer)
    {
        
        if ((answer == "A" && isNumA) || (answer == "B" && !isNumA))
        {   // ok! 
            Debug.Log("Answer: " + answer + ", Respuesta Correcta");
        }
        else
        {   //error
            Debug.Log("fallo:  " + answer + ", Respuesta Incorrecta");
        }

        this.gameObject.SetActive(false);

    }

}

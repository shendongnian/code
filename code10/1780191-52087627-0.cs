    using System.Collections;
       using System.Collections.Generic;
       using UnityEngine;
       using UnityEngine.UI;
    
    public class squidCoin : MonoBehaviour {
    
    
    public Text coinDisplay;
    public int addMoneyAmmount;
    public int squidCoins;
    public float saveInterval;
    public float paycheckTime;
    
    // Use this for initialization
    void Start () {
    squidCoins = 50;
    PlayerPrefs.SetInt("SquidCoinsSaves", squidCoins); //your string name was wrong
     StartCoroutine(moneyADD());
     StartCoroutine("SaveMoney");
    
    
      }
    
    public void squidCoinPayCheck(int squidCoinsToAdd){
        squidCoins += squidCoinsToAdd;
    
      }
    
      public void Awake(){
      //PlayerPrefs.GetInt("SquidCoinsSaves"); //you can not get it like this, first you must equal this ti intiger type varible
      }
    
    public void minusSquidCoin(int squidCoinsToSubtract){
    if(squidCoins - squidCoinsToSubtract < 0){
            Debug.Log ("Oops Hes Broke");
            squidCoins += addMoneyAmmount;
        }
        else{
        squidCoins -= squidCoinsToSubtract;
        }
    
    }
    
    
      IEnumerator moneyADD(){
         yield return new WaitForSeconds(paycheckTime);
         squidCoins += addMoneyAmmount;
     }
    
     IEnumerator SaveMoney (){
         while (true)
         {
                 yield return new WaitForSeconds(saveInterval);
                 PlayerPrefs.SetInt("SquidCoinsSaves", squidCoins); //string name was wrong
    
         }
     }
    
    
    // Update is called once per frame
    void Update () {
     coinDisplay.text = "You Have: " + PlayerPrefs.GetInt("SquidCoinsSaves");
    }
    }

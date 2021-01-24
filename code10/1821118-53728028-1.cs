    public class QuizScript : MonoBehaviour {
      public System.Collections.Generic.Dictionary<string, int> characteristic = new Dictionary<string, int>();
      //public int snake = 0;
      //public int centipede = 0;
      //constructor initializes your set
      public QuizScript() {
            characteristic.Add("snake",0);
            characteristic.Add("centipede",0);	        
      }
      public void Q2C1() //question 2 choice 1
      {
          characteristic["snake"] += 1;
          Debug.Log("Snake = " + characteristic["snake"].ToString()); //for me to see if it works
      }
      public void Q3C1() //question 3 choice 1
      {
          characteristic["centipede"] += 1;
          Debug.Log("Centipede = " + characteristic["centipede"].ToString());
      }
    }

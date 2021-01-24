    public class Player : MonoBehaviour
    {
    
      static public Player s_Singleton;
    
      private void Awake(){
        s_Singleton = this; //There are better ways to implement the singleton pattern, but there is not the point of your question
      }
        
    }

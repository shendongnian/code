     using UnityEngine; 
     using System.Collections;
 
     public class ExampleClass : MonoBehaviour 
     {
         public Transform other;
 
         void Example()
         {
             if (other && transform.position == other.position)
             {
                 print("I'm at the same place as the other transform!");
             }
         }
     }

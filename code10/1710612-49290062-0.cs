     using UnityEngine;
     using System.Collections;
     using UnityEngine.SceneManagement;
     
     public class ExampleClass : MonoBehaviour
     {
         void Start ()
         {
             // Create a temporary reference to the current scene.
             Scene currentScene = SceneManager.GetActiveScene ();
     
             // Retrieve the name of this scene.
             string sceneName = currentScene.name;
     
             if (sceneName == "Example 1") 
             {
                 // Do something...
             }
             else if (sceneName == "Example 2")
             {
                 // Do something...
             }
     
             // Retrieve the index of the scene in the project's build settings.
             int buildIndex = currentScene.buildIndex;
     
             // Check the scene name as a conditional.
             switch (buildIndex)
             {
             case 0:
                 // Do something...
                 break;
             case 1:
                 // Do something...
                 break;
             }
         }
     }

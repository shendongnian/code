    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    
    public class LoadScenes : MonoBehaviour
    {
        // Use this for initialization
        void Start ()
        { 
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
            StartCoroutine(WaitForSceneLoad(SceneManager.GetSceneByName("The Space Station")));        
        }
    
        public IEnumerator WaitForSceneLoad(Scene scene)
        {
            while (!scene.isLoaded)
            {
                yield return null;
            }
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
        }
    }

    using UnityEngine;
    using UnityEngine.SceneManagement;
    public class GetActiveSceneExample : MonoBehaviour
    {
        void Start()
        {
            Scene scene = SceneManager.GetActiveScene();
            Debug.Log("Active scene is '" + scene.name + "'.");
        }
    }

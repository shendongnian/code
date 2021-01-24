    using UnityEngine;
    using UnityEngine.SceneManagement;
    public class LoadLevel : MonoBehaviour {
      public string levelName;
	  public void LoadMyLevel()
       {
          SceneManager.LoadScene(levelName);
       }
    }

    using UnityEngine;
    using UnityEngine.UI;
    public class EnableUI : MonoBehaviour {
        public Image GameOverImage;
    	// Use this for initialization
    	void Start () {
            GameOverImage.gameObject.SetActive(false);
    	}
    	
    	// Update is called once per frame
    	void Update () {
    		if(Input.GetKeyDown(KeyCode.Space))
            {
                GameOverImage.gameObject.SetActive(true);
            }
    	}
    }

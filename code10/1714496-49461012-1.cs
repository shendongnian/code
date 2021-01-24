    using UnityEngine;
    public class EnableUI : MonoBehaviour {
        // This is a canvas with your game over image nested as a child image UI under it
        public GameObject GameOverObject;
    	// Use this for initialization
    	void Start () {	}
    	
    	// Update is called once per frame
    	void Update () {
    		if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(GameOverObject);
            }
    	}
    }

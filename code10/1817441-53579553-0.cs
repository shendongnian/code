    public GameObject[] objs = 
          SceneManager.GetSceneByName(sceneToLoad).GetRootGameObjects(); 
    foreach(GameObject go in objs)
    {
        if(go.name == "UIM")
        {
            this.gameObject.GetComponent<SpriteRenderer> ().sprite = 
              go.GetComponent<Manager> ().spriteImages [1];
            break;
        }
    }

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }
    
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           //Do something you need
           Debug.Log("Back button is pressed");
        }
    }

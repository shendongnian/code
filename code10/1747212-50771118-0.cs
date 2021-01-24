    GameObject obj = null;
    
    void Start()
    {
        //Create new one
        obj = new GameObject();
    }
    
    void Update()
    {
        //Check if 50 frames has passed
        if (Time.frameCount % 50 == 0)
        {
            //Destroy old one
            if (obj != null)
                DestroyImmediate(obj);
    
            //Create new one again
            obj = new GameObject();
        }
    }

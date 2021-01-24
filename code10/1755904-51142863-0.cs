    public GameObject[] objects;
    void Start () {
        objects = GameObject.FindGameObjectsWithTag("isari");  
    	Debug.Log (objects.Length);
    }

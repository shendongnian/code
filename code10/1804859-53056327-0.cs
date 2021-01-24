    public GameObject Ending;
    
    private void Start()
    {
       Ending = GameObject.Find("End Determination Object").GetComponent<Collider2D>; //this doesn't work
    }

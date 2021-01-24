    public Scrollbar scrollBar;
    private float oldValue;
    
    void Start()
    {
        oldValue = scrollBar.size;
    }
    
    void Update()
    {
        //Check if size changed
        if (!Mathf.Approximately(oldValue, scrollBar.size))
        {
            //It changed. Update old value with the new value
            oldValue = scrollBar.size;
    
            //Show the data
            Debug.Log("Size Changed!: " + scrollBar.size);
        }
    }

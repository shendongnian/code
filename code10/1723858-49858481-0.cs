    public Scrollbar sb;
    
    void OnEnable()
    {
        //Register Scrollbar Event
        sb.onValueChanged.AddListener(scollBarChanged);
    }
    
    //Called when Scrollbar value changes
    private void scollBarChanged(float value)
    {
        Debug.Log("Input Changed");
    }
    
    void OnDisable()
    {
        //Un-Register Scrollbar Event
        sb.onValueChanged.RemoveAllListeners();
    }

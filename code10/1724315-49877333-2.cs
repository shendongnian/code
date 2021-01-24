    ScrollSizeChanger otherScript;
    
    void Awake()
    {
        GameObject obj = GameObject.Find("OtherObj");
        otherScript = obj.GetComponent<ScrollSizeChanger>();
    }
    
    void OnEnable()
    {
        //Reigister to event
        otherScript.OnSizeChanged += SizeChangedCallBack;
    }
    
    private void SizeChangedCallBack(float oldValue, float newValue)
    {
        Debug.Log("Size changed. Old value: " + oldValue + " New value: " + newValue);
    }
    
    void OnDisable()
    {
        //Un-Reigister to event
        otherScript.OnSizeChanged -= SizeChangedCallBack;
    }

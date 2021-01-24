    public Toggle toggle1;
    public Toggle toggle2;
    public Toggle toggle3;
    
    void OnEnable()
    {
        //Register Toggle Events
        toggle1.onValueChanged.AddListener(delegate { ToggleCallBack(toggle1); });
        toggle2.onValueChanged.AddListener(delegate { ToggleCallBack(toggle2); });
        toggle3.onValueChanged.AddListener(delegate { ToggleCallBack(toggle3); });
    }
    
    private void ToggleCallBack(Toggle toggle)
    {
        if (toggle == toggle1)
        {
            //Your code for Toggle 1
            Debug.Log("Toggled: " + toggle1.name);
        }
    
        if (toggle == toggle2)
        {
            //Your code for Toggle 2
            Debug.Log("Toggled: " + toggle2.name);
        }
    
        if (toggle == toggle3)
        {
            //Your code for Toggle 3
            Debug.Log("Toggled: " + toggle3.name);
        }
    }
    
    void OnDisable()
    {
        //Un-Register Toggle Events
        toggle1.onValueChanged.RemoveAllListeners();
        toggle2.onValueChanged.RemoveAllListeners();
        toggle3.onValueChanged.RemoveAllListeners();
    }

    public Toggle toggle1;
    
    void OnEnable()
    {
        //Register Toggle Events
        toggle1.onValueChanged.AddListener(delegate
        {
            ToggleCallValueChanged(toggle1);
        });
    }
    
    private void ToggleCallValueChanged(Toggle toggle)
    {
        Debug.Log("Toggle: " + toggle + " is " + toggle.isOn);
    }
    
    void OnDisable()
    {
        //Un-Register Toggle Events
        toggle1.onValueChanged.RemoveAllListeners();
    }

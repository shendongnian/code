    public GameObject Gun;
    
    public Transform magTransform;
    public GameObject mag;
    
    
    public Button instantiateButton;
    
    void OnEnable()
    {
        //Register Button Events
        instantiateButton.onClick.AddListener(() => buttonCallBack(instantiateButton));
    }
    
    private void buttonCallBack(Button buttonPressed)
    {
        if (buttonPressed == instantiateButton)
        {
            //Your code for Instantiate button 
            Instantiate(mag, magTransform.position, magTransform.rotation);
        }
    }
    
    void OnDisable()
    {
        //Un-Register Button Events
        instantiateButton.onClick.RemoveAllListeners();
    }

    //Add your slider from the Editor
    public Slider sliderRef;
    //Add your light from the Editor
    public Light lightRef;
    void OnEnable()
    {
        //Subscribe to the Slider Click event
        sliderRef.onValueChanged.AddListener(sliderCallBack);
    }
    //Will be called when Slider changes
    void sliderCallBack(float value)
    {
        Debug.Log("Slider Value Changed: " + value);
        lightRef.intensity = sliderRef.value;
    }
    void OnDisable()
    {
        //Un-Subscribe To Slider Event
        sliderRef.onValueChanged.RemoveAllListeners();
    }

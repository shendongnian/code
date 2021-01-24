    Slider[] sliders;
    
    void Start()
    {
        //Find Sliders
        sliders = FindObjectsOfType<Slider>() as Slider[];
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Loop thrpugh sliders and reset them
            for (int i = 0; i < sliders.Length; i++)
                sliders[i].value = 0;
        }
    }

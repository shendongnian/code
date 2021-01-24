    public GameObject obj1;
    private void Update()
    {
        if(Input.GetButton("Button1") // or however you access your button 1
        {
            obj1.SetActive(true);
        } else if (Input.GetButton("Button2") // or however you access your button2
        {
            obj1.SetActive(false);
        }
    }

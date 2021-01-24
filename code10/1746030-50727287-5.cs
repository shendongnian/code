    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Set Windows Volume 70%  
            SetSystemVolume(0.70f, VolumeUnit.Scalar);
        }
    }

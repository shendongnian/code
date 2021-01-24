    void Update()
    {
        if (Input.GetKey("up") == true || Input.GetKey("down") == true || Input.GetKey("left") == true || Input.GetKey("right") == true)
        {
            Drive();
            if (!CarEngine.isPlaying)
                CarEngine.Play();
        }
        else
        {
            if (CarEngine.isPlaying)
            {
                Debug.Log("Stop playing....");
                CarEngine.Stop();
            }
        }
    }

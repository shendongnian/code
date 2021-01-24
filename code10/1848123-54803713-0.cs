     void Update()
    {
        if(isTracked)
        {
            if(Input.GetKey(KeyCode.W))
            {
                //using forward for moving object in z axis only. 
                //Also using local position since you need movement to be relative to image target
                //Global forward can be very different depending on your World Center Mode
                capsule.transform.localPosition += Vector3.forward * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                capsule.transform.localPosition -= Vector3.forward * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                //Using Vector3.left and right to be make sure movement is in X axis.
                capsule.transform.localPosition += Vector3.left * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                capsule.transform.localPosition += Vector3.right * Time.deltaTime;
            }
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (var touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    //For left half screen
                    if (touch.position.x <= screenMidPoint && finId1 == -1)
                    {
                        p1StartPos = touch.position;
                        p1StartTime = Time.time;
                        finId1 = touch.fingerId;
                    }
                    //For right half screen
                    else if (touch.position.x > screenMidPoint && finId2 == -1)
                    {
                        p2StartPos = touch.position;
                        p2StartTime = Time.time;
                        finId2 = touch.fingerId;
                    }
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    if (touch.fingerId == finId1)
                    {
                        finId1 = -1;
    
                        p1EndTime = Time.time;
                        p1EndPos = touch.position;
                        p1DeltaSwipe = p1EndPos - p1StartPos;
    
                        if (p1DeltaSwipe.y > 0 && Time.time > p1NextFire)
                        {
                            p1NextFire = Time.time + fireRate;
       
                            // p1 Shoot code is here
                        }
                    }
                    else if (touch.fingerId == finId2)
                    {
                        finId2 = -1;
    
                        p2EndTime = Time.time;
                        p2EndPos = touch.position;
                        p2DeltaSwipe = p2EndPos - p2StartPos;
    
                        if (p2DeltaSwipe.y > 0 && Time.time > p2NextFire)
                        {
                            p2NextFire = Time.time + fireRate;
    
                            // p2 Shoot code is here
                        }
                    }
                }
            }
        }
    }

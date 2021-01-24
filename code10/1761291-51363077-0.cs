    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {   
                if (Input.touchCount == 1)
                {
                    Spawnpin();
                }
            }
        }
    }

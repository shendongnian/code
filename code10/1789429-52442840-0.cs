    const float nSecond = 2f;
    
    float timer = 0;
    bool entered = false;
    
    public void PointerEnter()
    {
        entered = true;
    }
    
    public void PointerExit()
    {
        entered = false;
    }
    
    void Update()
    {
        //If pointer is pointing on the object, start the timer
        if (entered)
        {
            //Increment timer
            timer += Time.deltaTime;
    
            //Load scene if counter has reached the nSecond
            if (timer > nSecond)
            {
                SceneManager.LoadScene("SceneName");
            }
        }
        else
        {
            //Reset timer when it's no longer pointing
            timer = 0;
        }
    }

    bool initialized = false;
    
    void OnlyCalledOnce(){
        if (initialized)
        {
            DoesNothing();
        }
        else
        {
        // firsttimecode
        }
        initialized = true;
    }

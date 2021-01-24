    void Update()
        {    
           if(CrossPlatformInputManager.GetKeyDown(KeyCode.Space))
               playAudio.Play()
        
           if (CrossPlatformInputManager.GetKeyUp(KeyCode.Space))
               playAudio.Stop()
        }

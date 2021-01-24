    void Run() {
         while (serviceIsRunning)
         {
         try {
             Image image = Camera.CaptureImage();
    
             CallRestAPI(image);
    
             Thread.Sleep( (int) (1000 / framesPerSecond) );
         }
         catch (Exception ex)
         {
             Log.Error(ex);
         }
         } 
    }

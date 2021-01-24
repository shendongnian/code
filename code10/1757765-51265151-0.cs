    public  class FileMonitorService
        {
            private bool stopProcessing = false;
    
            public  void StartMonitoringForNewFiles(RobotParameters parameters)
            {
                try
                {
                    while (stopProcessing == false)
                    {
                        
                            stopProcessing = IsFileReady(parameters);
                        Thread.Sleep(5000);      // sleeps for 5 seconds 
    
                        if (stopProcessing == true)
                        {
                            break;      // get out of loop since file is ready
                        }
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
    
            private bool IsFileReady(RobotParameters parameters)
            {
                    try
                    {
    // code to try opening a file goes here
    // or code to see if files exist goes here
    
    // assuming file was opened with no errors and is ready for processing
    
                        return true;
                    }
                    catch (Exception e)
                    {
    
    // file is not ready for processing
    // and could not be opened
                        return false;
    
                    }
                }
    
    
                return false;
    
                }
            
    
        }
     

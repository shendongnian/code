     foreach (var process in Process.GetProcessesByName("RobloxPlayerBeta"))
            {
                process.Kill();
            }
    
            materialRaisedButton16.Text = "Successfully killed process!";
    
            // sleep for 2s WITHOUT freezing GUI
    
            Task.Delay(2000).ContinueWith(()=>{
                    materialRaisedButton16.Text = "Click to kill process";
              }, TaskScheduler.FromCurrentSynchronizationContext()); // this is to make it run in the UI thread again

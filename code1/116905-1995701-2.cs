        // global variable
            string timeelepse = string.empty; 
       // in button click handler
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                
                sw.Start();
        
                System.Threading.Thread t = new System.Threading.Thread(delegate()
                {
                    while (true)
                    {
                    TimeSpan ts = sw.Elapsed;
    
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
    
                    timeelepse = elapsedTime;
                    
                      UpdateLabel();
                    }
                });
                t.Start();

    while (true)
    {
       //keep checking if timer expired or app closed externally (ie. by user)
       if (dtEndTime <= DateTime.Now || p.HasExited)  {
          try {
              if (!p.HasExited)  // if the app hasn't already exitted...
              {
                 if (!p.CloseMainWindow())  // did message get sent? 
                 {
                    if (!p.HasExited)  //has app closed yet?
                    {
                       p.Kill();  // force app to exit
                       p.WaitForExit(2000);  // a few moments for app to shut down
                    }
                 }
                 p.Close();  // free resources
              }                        
           }
          catch { // blah blah }
          break;
       }
       System.Threading.Thread.Sleep(500);
    }

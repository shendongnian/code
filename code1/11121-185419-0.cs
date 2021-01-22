    try
    {
       foreach(string command in S) // command is something like "c:\a.exe"
       {
          using(p = Process.Start(command))
          {
            // I literally put nothing in here.
          }
        } 
    }
    catch (Exception e)
    {
        // notify of process failure
    }

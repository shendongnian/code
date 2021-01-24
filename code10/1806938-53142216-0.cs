    for (var i = 0; i < retryCount; i++)
    {
       try
       {
           YourAction();
           break; // success
       }
       catch { /*ignored*/ }
       
       // give a little breath..
       Thread.Sleep(50); 
    }

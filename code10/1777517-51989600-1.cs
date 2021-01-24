    // declare baseUrl in confing file by ex
    // Startup is your Startup class
    using (WebApp.Start<Startup>(baseUrl))
    {
         System.Console.WriteLine($"Listening on {baseUrl}");
    	 Thread.Sleep(Timeout.Infinite);
    }

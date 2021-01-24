    var timer = new System.Timers.Timer();
    
    timer.Interval = TimeSpan.FromSeconds(60).TotalMilliseconds;
    timer.Elapsed += async (sender, e) => 
    {
        timer.Stop();
        
        var response = await PingApi();
    
        if (ContainsConfigurationData(response))
        {
            ConfigureProgram(response);
        }
        else
        {
            timer.Enabled = true;
        }
    };
    timer.Enabled = true;
    
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();

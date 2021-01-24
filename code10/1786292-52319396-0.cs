    var timer = new System.Timers.Timer();
    
    timer.Interval = TimeSpan.FromSeconds(60).TotalMilliseconds;
    timer.Elapsed += async (sender, e) => 
    {
        var response = await PingApi();
        if (ContainsConfigurationData(response))
        {
            timer.Stop();
            timer.Dispose();
            ConfigureProgram(response);
        }
    };
    timer.Enabled = true;
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();

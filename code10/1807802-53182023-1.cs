    while (true) {
        // Long-poll the API
    
        StopWatch sw = StopWatch.StartNew();
        var response = await http.GetAsync(buildUri());
    
        Console.WriteLine("Resp: " + response.ToString());
        Console.WriteLine("CONTENT:");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    
        int milliseconds = 10000 - sw.ElapsedMilliSeconds;
        if (milliseconds > 0)
        {
            await Task.Delay(milliseconds);
        }
    }

    private static async Task TimeACoffee()
    {
       var stopwatch = new System.Diagnostics.Stopwatch();
       stopwatch.Start();
    
    
       await MakeACupOfCoffee();
    
       stopwatch.Stop();
       Console.WriteLine($"\n\nTime taken : {stopwatch.Elapsed}");
    
       Console.ReadLine();
    }
    
    private static async Task MakeACupOfCoffee()
    {
       await WaitForTheKettleToBoil();
       await GetCup();
       await AddCoffee();
       await AddMilk();
       await AddSugar();
    }
    
    private static async Task WaitForTheKettleToBoil()
    {
       Console.WriteLine("Waiting for the kettle to boil...");
       await Task.Delay(100);
    }
    
    private static async Task AddMilk()
    {
       Console.WriteLine("Adding milk");
       await Task.Delay(100);
    }
    
    private static async Task AddSugar()
    {
       Console.WriteLine("Adding sugar");
       await Task.Delay(100);
    }
    
    private static async Task GetCup()
    {
       Console.WriteLine("Getting cup");
       await Task.Delay(100);
    }
    
    private static async Task AddCoffee()
    {
       Console.WriteLine("Adding coffee");
       await Task.Delay(100);
    }

    static async Task Main(string[] args)
    {
     var cancellationToken = new CancellationTokenSource(); 
  	//Find eggs and bacon in database
    Task<List<Egg>> eggTask = FindEggsAsync(2,cancellationToken.Token);
    Task<List<Bacon>> baconTask = FindBaconAsync(3,cancellationToken.Token);
	Coffee cup = PourCoffee();
    if(cup.IsSpilled())
    {
     //Freak out and cancel tasks
     cancellationToken.Cancel();
     //Quit
     Environment.Exit(0)
    }  
    Console.WriteLine("coffee is ready");
	
    Juice oj = PourOJ();
    Console.WriteLine("oj is ready");
    
    List<Egg> eggs = await eggTask;
    List<Bacon> bacon = await baconTask;
    
    FryEggs(eggs);
    Console.WriteLine("eggs are ready");
    FryBacon(bacon);
    Console.WriteLine("bacon is ready");
    Console.WriteLine("Breakfast is ready!");
    //Dispose of token
    cancellationToken.Dispose();
    }

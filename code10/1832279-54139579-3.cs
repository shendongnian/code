    private static void WaitForTheKettleToBoil()
    {
       Console.WriteLine("Waiting for the kettle to boil...");
    }
    private static async Task MakeACupOfCoffee()
    {
       // start the task 
       var waitForTheKettleToBoilTask = Task.Run(WaitForTheKettleToBoil);
    
       // this needs to be first
       await GetCup();
    
       // when this is all completed you have a coffee
       await Task.WhenAll( AddCoffee(), AddMilk(), AddSugar());
    
       // wait for the kettle to boil
       //task.Wait();
       //or 
       await Task.WhenAll(waitForTheKettleToBoilTask);
    }

    private static void WaitForTheKettleToBoil()
    {
       Console.WriteLine("Waiting for the kettle to boil...");
    }
    private static async Task MakeACupOfCoffee()
    {
       // start the task (yehaa)
       var waitForTheKettleToBoilTask = Task.Run(WaitForTheKettleToBoil);
    
       // need a cup before we can add anything to it
       await GetCup();
    
       // when this is all completed you have a coffee
       await Task.WhenAll( AddCoffee(), AddMilk(), AddSugar(), waitForTheKettleToBoilTask);
    }

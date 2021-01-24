    private async Task GetData()
    {    
        HerdsRESTFulService herdService = new HerdsRESTFulService();
        herds = await herdService.GetAllAsync();
        Console.WriteLine("Hello");
    }

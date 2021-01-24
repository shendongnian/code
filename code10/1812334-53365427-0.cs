    public async Task<List<PcThing>> LoadThings()
    {
        return await App.WebApiManager.GetCustomerThinksAsync();
    }
    

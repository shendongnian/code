    private async Task GetLiveRate()
    {                                   
        var liveRATE = await GetLiveRateAsync(); 
        if (liveRATE > 0)
            SendInitialPO(liveRATE);        
    }       
    private async Task<int> GetLiveRateAsync()
    {            
        var productResponseInitialStep = await productClient.GetProductTickerAsync(Currency);                
        if (productResponseInitialStep.StatusCode == HttpStatusCode.OK)
          return 100;
        return 0            
    }

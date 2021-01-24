    private int liveRATE = 0;
    private async Task GetLiveRate()
    {                                   
        await GetLiveRateAsync(); 
        if (liveRATE > 0)
            SendInitialPO(liveRATE);        
    }       
    private async Task GetLiveRateAsync()
    {            
        var productResponseInitialStep = await productClient.GetProductTickerAsync(Currency);                
        if (productResponseInitialStep.StatusCode == HttpStatusCode.OK)
        {
            liveRATE = 100;
        }            
    }

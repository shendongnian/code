    private int liveRATE = 0;
    private async Task GetLiveRate()
    {                                   
        await GetLiveRate(); 
        if (liveRATE > 0)
            SendInitialPO(liveRATE);        
    }       
    private async Task GetLiveRate()
    {            
        var productResponseInitialStep = await productClient.GetProductTickerAsync(Currency);                
        if (productResponseInitialStep.StatusCode == HttpStatusCode.OK)
        {
            liveRATE = 100;
        }            
    }

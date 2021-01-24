    public async Task<string> waitForCampaignLoadAsync(string uri)
    {
        var client=new HttpClient();
        for(int i=0;i<30;i++)
        {
            token.ThrowIfCancellationRequested();
            var json=client.GetStringAsync(uri);
            var container = JsonConvert.DeserializeObject<CampaignTempleteStatus>(json);
            if (container.status != "pending")
            {
                return container.status;
            }
            await Task.Delay(10000); 
        }
        return "Timed out!";
    }

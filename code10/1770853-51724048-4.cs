    public async Task<string> waitForCampaignLoadAsync(string uri,CancellationToken token=default)
    {
        var client=new HttpClient();
        for(int i=0;i<30;i++)
        {
            var json = await client.GetStringAsync(uri);
            var container = JsonConvert.DeserializeObject<CampaignTempleteStatus>(json);
            if (container.status != "pending")
            {
                return container.status;
            }
            await Task.Delay(10000,token); 
        }
        return "Timed out!";
    }

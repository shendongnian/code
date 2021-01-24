    public static async Task Main()
    {
        var client=new HttpClient(serverUrl);
        while(true)
        {
            var response=await client.GetAsync(relativeServiceUrl);
            if(!response.IsSuccessStatusCode)
            {
                //That was an error, do something with it
            }
            await Task.Delay(1000);
        }
    }

    public static async Task DoRestCall()
    {
        HttpClient client = new HttpClient();
        string responseBody = String.Empty;
        var sw = new Stopwatch();
        sw.Start();
        HttpResponseMessage response = await client.GetAsync("https://http://myrest.com");
        if (response.IsSuccessStatusCode)
        {        
            responseBody = await response.Content.ReadAsStringAsync();
        }
        sw.Stop();    
        Console.WriteLine($"{responseBody.Length} {sw.ElapsedMilliseconds}");
    }

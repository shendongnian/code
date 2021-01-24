    private static async Task GetRequestAsync(string url)
    {
        try
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Caught Exception: " + e.Message);
        }
    }

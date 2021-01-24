    public static async Task<string> GetKraken()
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync("https://api.kraken.com/0/public/Ticker?pair=XBTCAD");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }

    public static async Task<Double> GetJson()
            {
    
                using (var httpClient = new HttpClient())
                {
                    Uri uri = new Uri("https://api.cryptonator.com/api/ticker/btc-usd");
                    HttpResponseMessage response = await httpClient.GetAsync(uri);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        ExchangeRate rate = JsonConvert.DeserializeObject<ExchangeRate>(result); //Newtonsoft
                        return 1.2;
                    }
                    else
                    {
                        return -1; //Example value
                    }
                }
            }

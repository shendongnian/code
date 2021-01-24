    public string BtcToDollar(decimal btc)
    {
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://blockchain.com/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string methodename = "frombtc?currency=USD&value=" + HttpUtility.HtmlEncode(btc * 100000000);
            var response = client.GetAsync(methodename);
            return response.Result.Content.ReadAsStringAsync().Result;
        }
    }

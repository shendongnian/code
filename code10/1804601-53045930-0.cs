        [HttpGet]
        public async Task<IEnumerable<Result>> Get()
        {
            string Baseurl = "https://bittrex.com";
            string Parameters = "api/v1.1/public/getmarketsummaries";
            RootInfoCoins CoinsInfo = new RootInfoCoins();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri("");
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllCoins using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(Parameters);
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    string CoinResponse = Res.Content.ReadAsStringAsync().Result;
                    CoinsInfo = JsonConvert.DeserializeObject<RootInfoCoins>(CoinResponse);
                }
                return CoinsInfo.result;
            }

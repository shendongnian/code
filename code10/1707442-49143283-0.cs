    using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new
                        System.Net.Http.Headers.AuthenticationHeaderValue("Basic",
                            Convert.ToBase64String(
                                Encoding.ASCII.GetBytes(
                                    "user:pass")));
    
                    var result = await (await client.GetAsync("https://api.hitbtc.com/api/2/trading/balance")).Content
                        .ReadAsStringAsync();
                }

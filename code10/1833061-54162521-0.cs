                var url = "https://MyWebAPI.MyCompanyName.com/";
                using (var httpClient = new HttpClient())
                {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "Base64Credetials");
                    using (var response = await httpClient.GetAsync(url))
                        if (response.IsSuccessStatusCode)
                        {
                            var strResponse = await response.Content.ReadAsStringAsync();
                            MyObject result = JsonConvert.DeserializeObject<MyObject>(strResponse);
                            if (result != null)
                            {
                                //Your code here
                            }
                        }
                }

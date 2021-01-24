        `string url = "http://readabook.16mb.com/api/allcategory";///this link return an json
        List<SomeObjectTHatUwant> Response = new List<SomeObjectTHatUwant>();///the data you want
       private async Task LoadDataAsync(string uri)
            {
            
                string responseJsonString = null;
                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);
                        HttpResponseMessage response = await getResponse;
                        responseJsonString = await response.Content.ReadAsStringAsync();
                    Response = JsonBase<SomeObjectTHatUwant>.ReturnResultsList(responseJsonString);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
        }`

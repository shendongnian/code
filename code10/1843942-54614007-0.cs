    using (HttpResponseMessage response = await client.GetAsync(url)) // here you can use your own implementation i.e PostAsJsonAsync
            {
                using (HttpContent content = response.Content)
                {
                    string responseFromServer = await content.ReadAsStringAsync();
                    
                }
            }

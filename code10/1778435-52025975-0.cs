     HttpClient client = new HttpClient();
       client.BaseAddress = new Uri("https://sandbox-api.alopeyk.com");
       HttpResponseMessage response = client.PostAsync("api/v2/orders", new StringContent(jsonString, Encoding.UTF8, "text/json")).Result;  
                    if (response.IsSuccessStatusCode)
                    {
                        // Parse the response body. Blocking!
                       var  responseData = response.Content.ReadAsStringAsync().Result;                    
    
                    }
           

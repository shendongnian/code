     public async Task<string> GetServiceData(string srvUrl)
        {
            try
            {
              apiClient = new HttpClient(new NativeMessageHandler(throwOnCaptiveNetwork: false, customSSLVerification: false)); // SSL true if you have custom SLL in your API 
              apiClient.BaseAddress = new Uri(_yourbaseUrl); // Url where the service is hosted
              apiClient.DefaultRequestHeaders.Add("",""); //defualt req header key value in case any
              var respon = await apiClient.GetAsync(srvUrl).Result.Content.ReadAsStringAsync(); // svrUrl is the name of the api that you want to consume 
              if (respon != string.Empty)
              {
                   return respon;
              }
            }
            catch (HttpRequestException reqEx)
            {
               return string.Empty;
            }
            catch (Exception ex)
            {
               return string.Empty;
            }
        }

      public async Task<string> PostServiceData(string srvUrl, object srvModel)
        {
            try
            {
              var myContent = JsonConvert.SerializeObject(srvModel);//your parameter to the API
              var stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
              apiClient = new HttpClient(new NativeMessageHandler(throwOnCaptiveNetwork: false, customSSLVerification: true));// SSL true if you have custom SLL in your API
              apiClient.BaseAddress = new Uri(_yourbaseUrl); // Url where the service is hosted
              apiClient.DefaultRequestHeaders.Add("",""); //defualt req header key value in case any
              apiClient.DefaultRequestHeaders.Accept
                   .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
                var respon = await apiClient.PostAsync(srvUrl, stringContent);
                    var resReslt = respon.Content.ReadAsStringAsync().Result;
                    return resReslt;
                }
                else
                    return string.Empty;
            }
            catch (HttpRequestException reqEx)
            {
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

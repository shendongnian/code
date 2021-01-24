    public static async Task<string> GetResponseDataFromAPI(string apiRequestUrl, CancellationTokenSource cts = default)
    {
            cts = cts ?? new CancellationTokenSource(TimeSpan.FromSeconds(20));
            try
            {
                if (StaticItemsHelper.IsAppInBackground)
                {
                    //return await ViewHelper.GetBackgroundTaskReturnValue(apiRequestUrl);
                    var responseData = AuthRequestHelper.globalHttpClient.GetAsync(apiRequestUrl, cts.Token).Result;
                    var result = responseData.Content.ReadAsStringAsync().Result;
                    return result;
                }
                else
                {
                    var responseData = await AuthRequestHelper.globalHttpClient.GetAsync(apiRequestUrl, cts.Token);
                    var result = await responseData.Content.ReadAsStringAsync();
                    return result;
                }
            }
            catch (Exception ex)
            {
                INotifyHelper.iNotifyObject.IsDataLoading = false;
                // show error
                return "{ \"error\": {\"code\": " + $"\"{ex.HResult}\", \"message\": \"{ex.Message}\"" + "} }";
            }
    }

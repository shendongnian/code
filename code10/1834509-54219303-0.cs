    public static async Task<TResult> GetData<TResult>(string apiTarget)
    {
          using (var client = new HttpClient())
          {
               //setup client
               client.BaseAddress = new Uri(_API_BASE_URI);
               client.MaxResponseContentBufferSize = 9999999; 
               client.DefaultRequestHeaders.Accept.Clear();
               client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _TOKEN);
               TResult _Result = default(TResult);
               //make request
               HttpResponseMessage response = await client.GetAsync(apiTarget).ConfigureAwait(false);
               if (response.IsSuccessStatusCode)
               {
                   var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    
                   _Result = (TResult)JsonConvert.DeserializeObject<TResult>(content);
               }
               return _Result;
          }
    }

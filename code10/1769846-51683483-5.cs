    public class MyHttpClient : IMyClient
    { 
         public Task<string> GetRawDataFrom(string url)
         {
             var response = await client.GetAsync(url);
             if (response.IsSuccessStatusCode)
             {
                 return await response.Content.ReadAsStringAsync();
             }
         }
    }

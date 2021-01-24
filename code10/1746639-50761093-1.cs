    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    
    namespace TestHttpClient
    {
        static class Program
        {
            static async Task Main(string[] args)
            {
                try
                {
                    using (var httpClient = new HttpClient(new WinHttpHandler() { WindowsProxyUsePolicy = WindowsProxyUsePolicy.UseWinInetProxy }))
                    {
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                        string url = "https://jsonplaceholder.typicode.com/posts/1";                   
    
                        var response = await httpClient.GetAsync(url);
                        string jsonResult = await response.Content.ReadAsStringAsync();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    throw;
                }
            }
        }
    }

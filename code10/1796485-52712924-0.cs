    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.Storage;
    
    namespace Braytech_3.Services
    {
        public static class APIRequest
        {
    
            internal static async Task Request()
            {
                //Create an HTTP client object
                Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();
    
                //Add a user-agent header to the GET request. 
                var headers = httpClient.DefaultRequestHeaders;
    
                Uri requestUri = new Uri("https://json_url");
    
                //Send the GET request asynchronously and retrieve the response as a string.
                Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
                string httpResponseBody = "";
    
                try
                {
                    //Send the GET request
                    httpResponse = await httpClient.GetAsync(requestUri);
                    httpResponse.EnsureSuccessStatusCode();
                    httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
    
                    await APITempSave(httpResponseBody);
    
                }
                catch (Exception ex)
                {
                    
                }
            }
    
            internal static async Task APITempSave(string json)
            {
                StorageFolder tempFolder = ApplicationData.Current.TemporaryFolder;
    
                if (await tempFolder.TryGetItemAsync("APIData.json") != null)
                {
                    StorageFile APIData = await tempFolder.GetFileAsync("APIData.json");
                    await FileIO.WriteTextAsync(APIData, json);
                }
                else
                {
                    StorageFile APIData = await tempFolder.CreateFileAsync("APIData.json");
                    await FileIO.WriteTextAsync(APIData, json);
                }
    
            }
        }
    }

    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using Newtonsoft.Json;
    
    namespace UpdateWorkItemFiled0411
    {
        class Program
        {
            static void Main(string[] args)
            {
                string password = "xxxx";
                string credentials = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "username", password )));
    
                Object[] patchDocument = new Object[1];
    
                patchDocument[0] = new { op = "replace", path = "/relations/attributes/comment", value = "Adding traceability to dependencies" };
    
    
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
    
    
                    var patchValue = new StringContent(JsonConvert.SerializeObject(patchDocument), Encoding.UTF8, "application/json-patch+json");
    
                    var method = new HttpMethod("PATCH");
                    var request = new HttpRequestMessage(method, "http://server:8080/tfs/DefaultCollection/_apis/wit/workitems/21?api-version=1.0") { Content = patchValue };
                    var response = client.SendAsync(request).Result;
    
    
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
    
                    }
    
                }
            }
        }
    }

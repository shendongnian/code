     public static async void createtWorkItem()
            {
                string requestUrl = "http://TFS2015servername:8080/tfs/{collectionname}/{teamprojectname}/_apis/wit/workitems/$Defect?api-version=1.0";
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string json = serializer.Serialize(new object[]{new
                {
                    op = "add",
                    path = "/fields/System.Title",
                    value = "New Task from TFS 2015 REST API"
                }});
    
                HttpClientHandler authtHandler = new HttpClientHandler()
                {
                   // Credentials = CredentialCache.DefaultNetworkCredentials
                    Credentials = new NetworkCredential("username", "password", "domainname")
                };
    
                using (HttpClient client = new HttpClient(authtHandler))
                {
                    var method = new HttpMethod("PATCH");
    
                    var request = new HttpRequestMessage(method, requestUrl)
                    {
                        Content = new StringContent(json, Encoding.UTF8,
                            "application/json-patch+json")
                    };
                HttpResponseMessage hrm = await client.SendAsync(request);
                Console.WriteLine("Completed!");
            };
        }

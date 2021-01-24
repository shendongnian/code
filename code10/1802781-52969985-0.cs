     static async Task CallWebAPIAsync()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            WebRequestHandler webRequestHandler = new WebRequestHandler();
            webRequestHandler.UseDefaultCredentials = true;
             webRequestHandler.AllowPipelining = true;
            webRequestHandler.AllowAutoRedirect = false;
            webRequestHandler.Credentials = CredentialCache.DefaultCredentials;
            GlobalRedirectHandler globalRedirectHandler = new GlobalRedirectHandler() { InnerHandler = webRequestHandler };
            using (var client = new HttpClient(globalRedirectHandler))
            {
                client.BaseAddress = new Uri("https://apitest");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);
                client.Timeout = TimeSpan.FromSeconds(30000);
                //GET Method  
                var response = await client.GetAsync("user").ConfigureAwait(false); 
                if (response.IsSuccessStatusCode)
                {
                    var responseresult = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Id:{0}\tName:{1}", responseresult);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
                
            }
        }

            using (HttpClient client = new HttpClient())
            {
                JObject jsonModel = new JObject();
                client.BaseAddress = new Uri("http://localhost:3978/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var values = new[]
                        {
                            new KeyValuePair<string, string>("firstname", lastname),
                            new KeyValuePair<string, string>("lastname", lastname),
                            new KeyValuePair<string, string>("payloadFile", FileName)
                        };
                        foreach (var keyValuePair in values)
                        {
                            multipartFormDataContent.Add(new StringContent(keyValuePair.Value),
                            String.Format("\"{0}\"", keyValuePair.Key));
                        }
                        ByteArrayContent fileContent = new ByteArrayContent(File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/uploads/output/" + FileName)));
                        string FullxmlString = File.ReadAllText(Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/output/" + FileName)));
                        
                        
                        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("payloadFile") { FileName = "payloadFile" };
                        multipartFormDataContent.Add(fileContent);
                        HttpResponseMessage response = client.PostAsync("api/message", multipartFormDataContent).Result;
                        string returnString = response.Content.ToString();
                        using (HttpContent content = response.Content)
                        {
                            string res = "";
                            Task<string> result = content.ReadAsStringAsync();
                            res = result.Result;
                        }
                    }
           }

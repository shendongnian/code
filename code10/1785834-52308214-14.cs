    public static string GenerateAccessToken(string resource, string tenantId, string clientId,string secretKey)
            {
                var url = $"https://login.microsoftonline.com/{tenantId}/oauth2/token";
                var body = $"grant_type=client_credentials&client_id={clientId}&client_secret={secretKey}&resource={resource}";
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(url)
                };
                StringContent content = new StringContent(body);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                var result = client.PostAsync(url, content).Result;
                var json = JObject.Parse (result.Content.ReadAsStringAsync().Result);
                return json["access_token"].ToString();
            }

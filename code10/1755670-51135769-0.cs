    public static string PostWebApi(string postData)
    {           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64817/api/test");
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("value", postData)
                });
                var result = await client.PostAsync("/api/Membership/exists", content);
                string resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
            }
    }

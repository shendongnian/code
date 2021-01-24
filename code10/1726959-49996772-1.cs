    private static void Post()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.ExpectContinue = false;
                var content = new StringContent("test", Encoding.UTF8);
                var result = httpClient.PostAsync("http://localhost:9090", content).Result;
            }
        }

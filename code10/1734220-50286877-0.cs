        static async Task TestApiAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:33854/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result = await client.PostAsync("api/School", "hello", new JsonMediaTypeFormatter());
                result.EnsureSuccessStatusCode();
                // if it something returns
                string resultString = await result.Content.ReadAsAsync<string>();
                Console.WriteLine(resultString);
            }
        }

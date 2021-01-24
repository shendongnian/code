            using (var client = new HttpClient())
            {
                var response = await client.PostAsync("https://myaddress.com/path", new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                    { "username", "user" },
                    { "password", "mypass" }
                }));
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    // do something
                }
            }

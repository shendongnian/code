            using (var client = new HttpClient())
            {
                var response = await client.PostAsync("https://myaddress.com/path", new StringContent(JsonConvert.SerializeObject(new
                {
                    username = "user",
                    password = "password"
                }), Encoding.UTF8, "application/json"));
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    // do something
                }
            }

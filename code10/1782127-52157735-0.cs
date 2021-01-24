    using (var client = new HttpClient())
            {
                var uri = new Uri(string.Format($"{<yourURLString>}", string.Empty));
                var jsonTransport = "";
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                //client.DefaultRequestHeaders.Add("Content-type", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "JWT " + accessToken);
                var response = await client.PostAsync(uri, jsonPayload);
                string responseContent = await response.Content.ReadAsStringAsync();
            }

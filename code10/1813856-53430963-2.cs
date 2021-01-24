    using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) })
        {
            PostObject postObject = new PostObject
            {
                NotificationContent = new NotificationContent
                {
                    Name = "Campaign Name",
                    Title = "Expired Warning",
                    Body = "You have items that almost expired"
                }
            };
            var myContent = JsonConvert.SerializeObject(postObject);
            client.DefaultRequestHeaders.Add("X-API-Token", "{my api token}");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var builder = new UriBuilder(new Uri("https://appcenter.ms/api/v0.1/apps/KacangIjo/ShopDiaryApp/push/notifications"));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, builder.Uri);
            request.Content = new StringContent(myContent, Encoding.UTF8, "application/json");//CONTENT-TYPE header
            HttpResponseMessage response = await client.SendAsync(request);
        };

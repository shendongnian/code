            var filePath = @"F:\Projects\TestProjects\MSTeamsSample\MSTeamsSample\Files\Test File.docx";
            var fileName = Path.GetFileName(filePath);
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var endpoint = $"https://graph.microsoft.com/beta/groups/{groupId}/drive/items/root:/General/{fileName}:/content";
            using (var client = new HttpClient())
            {
                using (var content = new StreamContent(fileStream))
                {
                    content.Headers.Add("Content-Type", MimeMapping.GetMimeMapping(fileName));
                    // Construct the PUT message towards the webservice
                    using (var request = new HttpRequestMessage(HttpMethod.Put, endpoint))
                    {
                        request.Content = content;
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.Token);
                        // Request the response from the webservice
                        using (var response = await client.SendAsync(request))
                        {
                            // Check the response.
                        }
                    }
                }
            }

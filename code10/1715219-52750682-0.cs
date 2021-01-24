     public async Task<TResult> GetGmailInboxAttachmentById<TResult>(string messageId, string token, string id, string attachId)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var url = "https://www.googleapis.com/gmail/v1/users/me/messages/" + messageId + "/" + id + "/attachments" + "/" + attachId;
                HttpResponseMessage response = await httpClient.GetAsync(url);
                return await response.Content.ReadAsAsync<TResult>();
            }
        }
    foreach (var part in inbox.Payload.Parts)
                    {
                        if (!String.IsNullOrEmpty(part.Filename))
                        {
                            var attachId = part.Body.AttachmentId;
                            var attach = _gmailService.GetGmailInboxAttachmentById<MessagePartBody>(id, token, part.PartId, attachId).Result;
                            // Converting from RFC 4648 base64 to base64url encoding
                            // see http://en.wikipedia.org/wiki/Base64#Implementations_and_history
                            string attachData = attach.Data.Replace('_', '+');
                            attachData = attachData.Replace('_', '/');
                            byte[] data = Convert.FromBase64String(attachData);
                            string file = Convert.ToBase64String(data);
                            GetAttach.Add(file);
                        }
                    }

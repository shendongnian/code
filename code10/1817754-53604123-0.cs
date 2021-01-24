    if (message.Attachments != null && message.Attachments.Any())
    {
        using (HttpClient httpClient = new HttpClient())
        {
            // Skype & MS Teams attachment URLs are secured by a JwtToken, so we need to pass the token from our bot.
            if ((message.ChannelId.Equals(ChannelIds.Skype, StringComparison.InvariantCultureIgnoreCase) 
                || message.ChannelId.Equals(ChannelIds.Msteams, StringComparison.InvariantCultureIgnoreCase)))
            {
                var token = await new MicrosoftAppCredentials().GetTokenAsync();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
    
            foreach (Attachment attachment in message.Attachments)
            {
                using (var responseMessage = await httpClient.GetAsync(attachment.ContentUrl))
                {
                    using (var fileStream = await responseMessage.Content.ReadAsStreamAsync())
                    {
                        string path = Path.Combine(System.Web.HttpContext.Current.Request.MapPath("~\\Content\\Files"), attachment.Name);
                        using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
                        {
                            await fileStream.CopyToAsync(file);
                            file.Close();
                        }
                    }
                    var contentLenghtBytes = responseMessage.Content.Headers.ContentLength;
                    await context.PostAsync($"Attachment of {attachment.ContentType} type and size of {contentLenghtBytes} bytes received.");
                }
            }
        }
    }

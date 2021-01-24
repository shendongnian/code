    string channelToken = null;
    if ((activity.ChannelId.Equals("skype", StringComparison.InvariantCultureIgnoreCase)) 
    {
        var credentials = new MicrosoftAppCredentials(youBotAppId, yourBotAppPassword);
        channelToken = await credentials.GetTokenAsync();
    }
    foreach (var file in activity.Attachments)
    {
        // Determine where the file is hosted.
        var remoteFileUrl = file.ContentUrl;
    
        // Save the attachment to the system temp directory.
        var localFileName = Path.Combine(Path.GetTempPath(), file.Name)
        
        // Download the actual attachment
        using (var webClient = new WebClient())
        {
            if (!string.IsNullOrWhiteSpace(channelToken))
            {
                webClient.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", channelToken);
            }
            webClient.DownloadFile(remoteFileUrl, localFileName);
        }

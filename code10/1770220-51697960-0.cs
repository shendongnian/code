    foreach (string xmlMessage in await GetMesssageAttachments(userId))
    {
    string messageFileName = Path.GetRandomFileName();
    string messagesPath = Path.Combine(messagesFolder, messageFileName);
        var xmlMessageResponse = await _client.GetAsync(xmlMessage);
        using (FileStream fileStream = new FileStream(messagesPath, FileMode.Create))
        {
            await xmlMessageResponse.Content.CopyToAsync(fileStream);
        }
    }

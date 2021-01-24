    using (WebClient webClient = new WebClient())
    {
        var html = webClient.DownloadString("https://tlk.io/123");
        Match chatIdFinder = new Regex(@"Talkio\.Variables\.chat_id = '(?<chatid>\d+)'").Match(html);
        if (!chatIdFinder.Success) throw new ArgumentException("Could not find chat id");
        var chatId = chatIdFinder.Groups["chatid"].Value;
        var json = webClient.DownloadString($"https://tlk.io/api/chats/{chatId}/messages");
        JArray messages = JArray.Parse(json);
        var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        foreach (dynamic message in messages)
        {
            JToken chatMessage = message.body;
            JToken nickname = message.nickname;
            JToken timestamp = message.timestamp;
            var messageTime = epoch.AddSeconds(timestamp.Value<int>()).ToLocalTime();
            Console.WriteLine($"{messageTime}: {nickname.Value<string>()}: {chatMessage.Value<string>()}");
        }
    }

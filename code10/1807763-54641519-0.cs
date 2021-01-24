        bool updateActivities = new[] { Channels.Webchat, Channels.Emulator, Channels.Directline, }.Contains(activity.ChannelId);
            var incrementId = 0;
            //get current id
            if (updateActivities && activity.Id.Contains("|"))
            {
                int.TryParse(activity.Id.Split('|')[1], out incrementId);
            }
    foreach (var a in activities)
    {
        incrementId++;
        a.Id = string.Concat(activity.Conversation.Id, "|", incrementId.ToString().PadLeft(7, '0'));
        a.Timestamp = DateTimeOffset.UtcNow;
        a.ChannelData = string.Empty; // WebChat uses ChannelData for id comparisons, so we clear it here
    }
    var transcript = new Transcript(activities);
    
    await connectorClient.Conversations.SendConversationHistoryAsync(activity.Conversation.Id, transcript, cancellationToken: cancellationToken);

        var parameters = new ConversationParameters
        {
            Bot = new ChannelAccount(botId, botName),
            Members = new ChannelAccount[] { new ChannelAccount(userId) },
            ChannelData = new TeamsChannelData
            {
                Tenant = channelData.Tenant
            }
        };
        var conversationResource = await connectorClient.Conversations.CreateConversationAsync(parameters);

    using Microsoft.Bot.Builder.Teams;
    using Microsoft.Bot.Schema.Teams;
    using Microsoft.Bot.Connector.Teams;
    ...
    ConversationList channels = await teamsContext.Operations.FetchChannelListAsync(incomingTeamId);
    
    TeamDetails teamInfo = await teamsContext.Operations.FetchTeamDetailsAsync(incomingTeamId);
    
    ConnectorClient client = new ConnectorClient(new Uri(turnContext.Activity.ServiceUrl));
    List<TeamsChannelAccount> roster = (await client.Conversations
      .GetConversationMembersAsync(turnContext.Activity.Conversation.Id)
      .ConfigureAwait(false))
      .ToList()
      .ConvertAll(member =>
        {
          return teamsContext.AsTeamsChannelAccount(member);
        }
      );

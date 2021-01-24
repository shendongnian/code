    using Microsoft.Bot.Builder.Teams;
    using Microsoft.Bot.Schema.Teams;
    using Microsoft.Bot.Connector.Teams;
    ...
    ConversationList channels = await teamsContext.Operations.FetchChannelListAsync(incomingTeamId);
    
    TeamDetails teamInfo = await teamsContext.Operations.FetchTeamDetailsAsync(incomingTeamId);
    
    var roster = teamsContext.GetConversationParametersForCreateOrGetDirectConversation(turnContext.Activity.From).Members;
    List<TeamsChannelAccount> rosterTC = roster.ToList().ConvertAll(member =>
      {
        return teamsContext.AsTeamsChannelAccount(member);
      });
    await turnContext.SendActivityAsync($"You have {roster.Count} number of people in this group. You are {from.Name}");

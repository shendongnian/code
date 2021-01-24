	using System.Threading;
	using System.Threading.Tasks;
	using Microsoft.Bot.Builder;
	using Microsoft.Bot.Connector.Teams.Models;
	using Microsoft.Bot.Schema;
	namespace Microsoft.Bot.Connector.Teams
	{
		public static class TeamsExtensions
		{
			public static async Task<ConversationResourceResponse> CreateTeamsThreadAsync(
				this ITurnContext turnContext,
				Activity activity,
				CancellationToken cancellationToken = default(CancellationToken))
			{
				var connectorClient = turnContext.TurnState.Get<IConnectorClient>() as ConnectorClient;
				activity.ChannelData = turnContext.Activity.ChannelData;
				return await connectorClient.Conversations.CreateTeamsThreadAsync(turnContext.Activity.Conversation.Id, activity, cancellationToken);
			}
			public static async Task<ConversationResourceResponse> CreateTeamsThreadAsync(
				this IConversations conversations,
				string conversationId,
				Activity activity,
				CancellationToken cancellationToken = default(CancellationToken))
			{
				var channelData = activity.GetChannelData<TeamsChannelData>();
				var parameters = new ConversationParameters
				{
					ChannelData = new TeamsChannelData
					{
						Channel = channelData.Channel,
						Team = channelData.Team,
						Tenant = channelData.Tenant,
					},
					Activity = activity,
				};
				return await conversations.CreateConversationAsync(parameters, cancellationToken);
			}
		}
	}

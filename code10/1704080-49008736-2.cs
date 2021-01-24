    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            // Process each activity
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
            }
            // Webchat: getting an "event" activity for our js code
            else if (activity.Type == ActivityTypes.Event && activity.ChannelId == "webchat")
            {
                var receivedEvent = activity.AsEventActivity();
                if ("localeSelectionEvent".Equals(receivedEvent.Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    await EchoLocaleAsync(activity, activity.Locale);
                }
            }
            // Sample for Skype: locale is provided in ContactRelationUpdate event
            else if (activity.Type == ActivityTypes.ContactRelationUpdate && activity.ChannelId == "skype")
            {
                await EchoLocaleAsync(activity, activity.Entities[0].Properties["locale"].ToString());
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
        
        private async Task EchoLocaleAsync(Activity activity, string inputLocale)
        {
            Activity reply = activity.CreateReply($"User locale is {inputLocale}, you should use this language for further treatment");
            var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            await connector.Conversations.SendToConversationAsync(reply);
        }
    }

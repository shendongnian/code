    public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
    {
        if (activity.Type == ActivityTypes.Message)
        {
            if (activity.Text=="reset")
            {
                var message = activity as IMessageActivity;
    
                using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
                {
                    var botDataStore = scope.Resolve<IBotDataStore<BotData>>();
                    var key = new AddressKey()
                    {
                        BotId = message.Recipient.Id,
                        ChannelId = message.ChannelId,
                        UserId = message.From.Id,
                        ConversationId = message.Conversation.Id,
                        ServiceUrl = message.ServiceUrl
                    };
                    var userData = await botDataStore.LoadAsync(key, BotStoreType.BotConversationData, CancellationToken.None);
    
                    //var varName = userData.GetProperty<string>("varName");
                            
                    userData.SetProperty<object>("varName", null);
    
                    await botDataStore.SaveAsync(key, BotStoreType.BotConversationData, userData, CancellationToken.None);
                    await botDataStore.FlushAsync(key, CancellationToken.None);
                }
            }
    
            await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
        }
        else
        {
            HandleSystemMessage(activity);
        }
        var response = Request.CreateResponse(HttpStatusCode.OK);
        return response;
    }
    
    public class AddressKey : IAddress
    {
        public string BotId { get; set; }
        public string ChannelId { get; set; }
        public string ConversationId { get; set; }
        public string ServiceUrl { get; set; }
        public string UserId { get; set; }
    }

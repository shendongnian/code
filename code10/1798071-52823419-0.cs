    public async Task<HttpResponseMessage> Post()
    {
        using (var context = new SqlBotDataContext(ConfigurationManager.ConnectionStrings["BotDataContextConnectionString"].ConnectionString))
        {
            try
            {
                foreach(var botData in context.BotData)
                {
                    if(botData.BotStoreType == BotStoreType.BotPrivateConversationData)
                    {
                        var message = Activity.CreateMessageActivity();
                        message.ChannelId = botData.ChannelId;
                        message.Timestamp = botData.Timestamp;
                        message.From = new ChannelAccount(id: botData.UserId);
                        message.Conversation = new ConversationAccount(id: botData.ConversationId);
                        message.Recipient = new ChannelAccount(id: botData.BotId);
                        message.ServiceUrl = botData.ServiceUrl;
    
                        using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
                        {
                            var scopedData = scope.Resolve<IBotData>();
                            await scopedData.LoadAsync(default(CancellationToken));
                            //resetting the stack is not necessary, since .LoadAsync will fail silently, and reset it
                            //var stack = scope.Resolve<IDialogStack>();
                            //stack.Reset();
                            await scopedData.FlushAsync(default(CancellationToken));
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException err)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, err.Message);
            }
        }
    
        var response = Request.CreateResponse(HttpStatusCode.OK);
        return response;
    } 
   

        public async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                var userId = activity.From.Id;
                var message = activity.Text;
                if (!Utils.MessageDictionary.ContainsKey(userId))
                {
                    ConnectorClient connector = new ConnectorClient(new System.Uri(activity.ServiceUrl));
                    var reply = activity.CreateReply();
                    //save all incoming messages to a dictionary
                    Utils.MessageDictionary.Add(userId, message);
                    // this can be removed it just confirms it was saved
                    reply.Text = $"Message saved {userId} - {Utils.MessageDictionary[userId]}";
                    await connector.Conversations.ReplyToActivityAsync(reply);
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

    public sealed class CustomBotToUser : IBotToUser
    {
        private readonly IBotToUser inner;
        private readonly IConnectorClient client;
        public CustomBotToUser(IBotToUser inner, IConnectorClient client)
        {
            SetField.NotNull(out this.inner, nameof(inner), inner);
            SetField.NotNull(out this.client, nameof(client), client);
        }
        public async Task PostAsync(IMessageActivity message,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (message.Text == "I’m Sorry, I don’t have an answer for you. Please try and rephrase your question")
            {
                //save to permanant storage here
                //if you would like to use a database
                //I have a very simple database bot example here
                //https://github.com/JasonSowers/DatabaseBotExample
            }
            //user is the recipient
            var userId = message.Recipient.Id;
            //remove entry from dictionary
            Utils.MessageDictionary.Remove(userId);
            //this is just for testing purposes and can be removed
            try
            {
                await inner.PostAsync($"{userId} - {Utils.MessageDictionary[userId]}");
            }
            catch (Exception e)
            {
                await inner.PostAsync($"No entry found for {userId}");
            }
            await inner.PostAsync((Activity) message, cancellationToken);
        }
        public IMessageActivity MakeMessage()
        {
            return inner.MakeMessage();
        }
    }

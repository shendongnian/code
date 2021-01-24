    public class QuickTestBot_CSharpBot : IBot
        {
            private readonly IStatePropertyAccessor<DialogState> _dialogStateAccessor;
            private readonly ConversationState _conversationState;
            public QuickTestBot_CSharpBot(ConversationState conversationState)
            {
                _conversationState = conversationState ?? throw new ArgumentNullException(nameof(conversationState));
                _dialogStateAccessor = _conversationState.CreateProperty<DialogState>(nameof(DialogState));
    
                Dialogs = new DialogSet(_dialogStateAccessor);
                Dialogs.Add(new QuickDialog());
    
            }
    
            private DialogSet Dialogs { get; set; }
    
            public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
            {
                var activity = turnContext.Activity;
    
                var dc = await Dialogs.CreateContextAsync(turnContext);
    
                if (activity.Type == ActivityTypes.Message)
                {
                    // Ensure that message is a postBack (like a submission from Adaptive Cards
                    var channelData = JObject.Parse(dc.Context.Activity.ChannelData.ToString());
                    if (channelData.ContainsKey("postback"))
                    {
                        var postbackActivity = dc.Context.Activity;
                        // Convert the user's Adaptive Card input into the input of a Text Prompt
                        // Must be sent as a string
                        postbackActivity.Text = postbackActivity.Value.ToString();
                        await dc.Context.SendActivityAsync(postbackActivity);
                    }
                }
                ...

    public class TestEchoBotBot : IBot
    {
        private readonly TestEchoBotAccessors _accessors;
        private DialogSet _dialogs;
            
        public TestEchoBotBot(TestEchoBotAccessors accessors, ILoggerFactory loggerFactory)
        {
            if (loggerFactory == null)
            {
                throw new System.ArgumentNullException(nameof(loggerFactory));
            }
    
            _dialogs = new DialogSet(accessors.ConversationDialogState);
            _dialogs.Add(FormDialog.FromForm(HelpForm.BuildForm));
            _accessors = accessors ?? throw new System.ArgumentNullException(nameof(accessors));
        }
    
        public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (turnContext.Activity.Type == ActivityTypes.Message)
            {
                var dialogContext = await _dialogs.CreateContextAsync(turnContext, cancellationToken);
                if (turnContext.Activity.Text?.ToUpper() == "HELP")
                {
                    await dialogContext.BeginDialogAsync(typeof(HelpForm).Name, null, cancellationToken);
                }
                else
                {
                    var dialogResult = await dialogContext.ContinueDialogAsync(cancellationToken);
                    if ((dialogResult.Status == DialogTurnStatus.Cancelled || dialogResult.Status == DialogTurnStatus.Empty))
                    {
                        var responseMessage = $"You sent '{turnContext.Activity.Text}'\n";
                        await turnContext.SendActivityAsync(responseMessage);
                    }
                }                
            }
        }
    }

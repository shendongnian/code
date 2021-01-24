    public class MultiTurnPromptsBot : IBot
    {
        private const string WelcomeText = "Hi Feil Good evening!  \n\n I am Hentry your HR L&D virtual assistant. \n\n How can I help you with your learning today?";
        private const string UserInfoRequestText = "YEP! Let's do that. \n\n\n\n Can you share with me below information's: \n\n\n\n 1) What is your name? \n\n\n\n 2) What is your email? \n\n\n\n 3) Date of Meeting (MM/DD/YYYY)? \n\n\n\n Share the information for future proceeding as example like below \n\n\n\n \"sujan#sujan@gmail.com#12/30/2018\"";
    
        private readonly MultiTurnPromptsBotAccessors _accessors;
        private DialogSet _dialogs;
    
        public MultiTurnPromptsBot(MultiTurnPromptsBotAccessors accessors)
        {
            _accessors = accessors ?? throw new ArgumentNullException(nameof(accessors));
            _dialogs = new DialogSet(accessors.ConversationDialogState);
    
            var waterfallSteps = new WaterfallStep[]
            {
                UserInfoStepAsync,
                ConfirmStepAsync,
            };
                
            _dialogs.Add(new WaterfallDialog("details", waterfallSteps));
            _dialogs.Add(new TextPrompt("userinfo", ValidateUserInfoAsync));
            _dialogs.Add(new ConfirmPrompt("confirm"));
        }
    
    
        public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (turnContext.Activity.Type == ActivityTypes.Message)
            {
                var dialogContext = await _dialogs.CreateContextAsync(turnContext, cancellationToken);
                var results = await dialogContext.ContinueDialogAsync(cancellationToken);
    
                if (results.Status == DialogTurnStatus.Empty)
                {
                    var profile = await _accessors.UserProfile.GetAsync(turnContext, () => new UserProfile(), cancellationToken);
                    if (string.IsNullOrEmpty(profile.Name))
                    {
                        await dialogContext.BeginDialogAsync("details", null, cancellationToken);
                    }
                    else
                    {
                        //Profile has been retrieved, so load other dialogs here
                    }
                }
            }
            else if (turnContext.Activity.Type == ActivityTypes.ConversationUpdate)
            {
                if (turnContext.Activity.MembersAdded != null)
                {
                    await SendWelcomeMessageAsync(turnContext, cancellationToken);
                }
            }
                
            await _accessors.ConversationState.SaveChangesAsync(turnContext, false, cancellationToken);
            await _accessors.UserState.SaveChangesAsync(turnContext, false, cancellationToken);
        }
    
        private static async Task SendWelcomeMessageAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in turnContext.Activity.MembersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    var reply = turnContext.Activity.CreateReply();
                    reply.Text = WelcomeText;
                    await turnContext.SendActivityAsync(reply, cancellationToken);
                }
            }
        }
    
        private static async Task<DialogTurnResult> UserInfoStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.PromptAsync("userinfo", new PromptOptions { Prompt = MessageFactory.Text(UserInfoRequestText) }, cancellationToken);
        }
    
        private async Task<bool> ValidateUserInfoAsync(PromptValidatorContext<string> promptContext, CancellationToken cancellationToken)
        {
            var text = promptContext.Context.Activity.Text;
            var values = text.Split('#');
            if(values.Count() < 3)
            {
                await promptContext.Context.SendActivityAsync("Please provide the information in the following format: name#email@address.com#12/30/2018");
                return false;
            }
            string name = values[0];
            string email = values[1];
            string date = values[2];
    
            //todo: further validation of email and date
                
            return true;
        }
            
        private async Task<DialogTurnResult> ConfirmStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var userProfile = await _accessors.UserProfile.GetAsync(stepContext.Context, () => new UserProfile(), cancellationToken);
    
            string text = (string)stepContext.Result;
            var values = text.Split('#');
            userProfile.Name = values[0];
            userProfile.Email = values[1];
            userProfile.Date = DateTime.Parse(values[2]);
                
            await stepContext.Context.SendActivityAsync(MessageFactory.Text($"Thanks {userProfile.Name}."), cancellationToken);
    
            SendEmail(userProfile);
    
            return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
        }
    
        private static void SendEmail(UserProfile userProfile)
        {
            MailMessage mail = new MailMessage("you@yourcompany.com", userProfile.Email);
            SmtpClient client = new SmtpClient();
    
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            mail.Subject = "Email Subject";
            mail.Body = "Email body";
            client.Send(mail);
        }

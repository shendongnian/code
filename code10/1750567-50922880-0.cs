    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            /* Wait until the first message is received from the conversation and call MessageReceviedAsync 
            *  to process that message. */
            context.Wait(this.MessageReceivedAsync);
        }
            
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            /* When MessageReceivedAsync is called, it's passed an IAwaitable<IMessageActivity>. To get the message,
                *  await the result. */
            var message = await result;
            // var qnaAuthKey = Utils.GetAppSetting("QnAAuthKey");
            var qnaAuthKey = ConfigurationManager.AppSettings["QnAAuthKey"];
            var qnaKBId = ConfigurationManager.AppSettings["QnAKnowledgebaseId"];
            var endpointHostName = ConfigurationManager.AppSettings["QnAEndpointHostName"];
    
            // QnA Subscription Key and KnowledgeBase Id null verification
            if (!string.IsNullOrEmpty(qnaAuthKey) && !string.IsNullOrEmpty(qnaKBId))
            {
                await context.Forward(new BasicQnAMakerDialog(), AfterAnswerAsync, message, CancellationToken.None);
            }
            else
            {
                await context.PostAsync("Please set QnAKnowledgebaseId, QnAAuthKey and QnAEndpointHostName (if applicable) in App Settings. Learn how to get them at https://aka.ms/qnaabssetup.");
            }
    
        }
    
        private async Task AfterAnswerAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            // wait for the next user message
            context.Wait(MessageReceivedAsync);
        }
    
    }
    
    // Dialog for QnAMaker GA service
    [Serializable]
    public class BasicQnAMakerDialog : QnAMakerDialog
    {
        public BasicQnAMakerDialog() : base(new QnAMakerService(new QnAMakerAttribute(ConfigurationManager.AppSettings["QnAAuthKey"], ConfigurationManager.AppSettings["QnAKnowledgebaseId"], "No good match in FAQ.", 0.5, 1, ConfigurationManager.AppSettings["QnAEndpointHostName"])))
        {
        }
    
        protected override async Task RespondFromQnAMakerResultAsync(IDialogContext context, IMessageActivity message, QnAMakerResults result)
        {
            var answer = result.Answers.First().Answer;
            Activity reply = ((Activity)context.Activity).CreateReply();
            string[] qnaAnswerDate = answer.Split(';');
            int dataSize = qnaAnswerDate.Length;
    
            if (dataSize > 1 && dataSize <= 4)
            {
                var attachment = GetSelectedCard(answer);
                reply.Attachments.Add(attachment);
    
                await context.PostAsync(reply);
            }
            else
            {
                await context.PostAsync(answer);
            }
        }
    
        private async Task AfterBasicQnAMakeAnswerAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            context.Wait(MessageReceivedAsync);
        }
    
        private static Attachment GetSelectedCard(string answer)
        {
            int len = answer.Split(';').Length;
            switch (len)
            {
                case 4: return GetHeroCard(answer);
                default: //return GetHeroCard(answer);
                    return null;
            }
        }
    
        private static Attachment GetHeroCard(string answer)
        {
            string[] qnaAnswerData = answer.Split(';');
            string title = qnaAnswerData[0];
            string description = qnaAnswerData[1];
            string url = qnaAnswerData[2];
            string imageURL = qnaAnswerData[3];
            HeroCard card = new HeroCard
            {
                Title = title,
                Subtitle = description,
            };
            card.Buttons = new List<CardAction>
                                {
                                    new CardAction(ActionTypes.OpenUrl,"Learn More" ,value:url)
                                };
            card.Images = new List<CardImage>
                                {
                                    new CardImage(url=imageURL)
                                };
            return card.ToAttachment();
        }
    }

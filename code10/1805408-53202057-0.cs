    `[Serializable]
       public class ImagesForm : IDialog<ImagesForm>
        {
        [AttachmentContentTypeValidator(ContentType = "pdf")]
        [Prompt("please, provide us your resume")]
        public AwaitableAttachment file_CV;
        [Prompt("Your email ?")]
        public string email;
        //no actual validation on this at the moment.
        public ImagesForm()
        {
        }
        public async Task StartAsync(IDialogContext context)
        {
            var state = this;
            var form = new FormDialog<ImagesForm>(state, BuildForm, FormOptions.PromptInStart);
            context.Call(form, AfterBuildForm);
        }
        private async Task AfterBuildForm(IDialogContext context, IAwaitable<ImagesForm> result)
        {
            context.Done(result);
        }
        public static IForm<ImagesForm> BuildForm()
        {
            OnCompletionAsyncDelegate<ImagesForm> onFormCompleted = async (context, state) =>
            {
                
                var botAccount = new ChannelAccount(name: $"{ConfigurationManager.AppSettings["BotId"]}", id: $"{ConfigurationManager.AppSettings["BotEmail"]}".ToLower());
                var userAccount = new ChannelAccount(name: "Name", id: $"{ConfigurationManager.AppSettings["UserEmail"]}");
                MicrosoftAppCredentials.TrustServiceUrl(@"https://email.botframework.com/", DateTime.MaxValue);
                var connector = new ConnectorClient(new Uri("https://email.botframework.com/" ));
                var conversationId = await connector.Conversations.CreateDirectConversationAsync(botAccount, userAccount);
                IMessageActivity message = Activity.CreateMessageActivity();
                message.From = botAccount;
                message.Recipient = userAccount;
                message.Conversation = new ConversationAccount(id: conversationId.Id);
                message.Text = $"Resume recieved from {state.email.ToString()}";
                message.Locale = "en-Us";
                
                var resume = state.file_CV.Attachment;
                message.Attachments = new List<Attachment>();
                message.Attachments.Add(resume);
                try
                {
                    await connector.Conversations.SendToConversationAsync((Activity)message);
                }
                catch (ErrorResponseException e)
                {
                    Console.WriteLine("Error: ", e.StackTrace);
                }
              
                await context.PostAsync("Here is a summary of the data you submitted:");
 
                var resumeSize = await RetrieveAttachmentSizeAsync(state.file_CV);
                //Do stuff with the resume on 
                await context.PostAsync($"Your resume is '{state.file_CV.Attachment.Name}' - Type: {state.file_CV.Attachment.ContentType} - Size: {resumeSize} bytes");
                await context.PostAsync($"Your email is {state.email.ToString()}");
            };
            return new FormBuilder<ImagesForm>()
                        .Message("Welcome, please submit all required documents")
                        .OnCompletion(onFormCompleted)
                        .Build();
        }
        private static async Task<long> RetrieveAttachmentSizeAsync(AwaitableAttachment attachment)
        {
            var stream = await attachment;
            return stream.Length;
        }
    }`

    `	[Serializable]
    public class ImagesForm : IDialog<ImagesForm>
    {
        [AttachmentContentTypeValidator(ContentType = "pdf")]
        [Prompt("please, provide the file")]
        public AwaitableAttachment file_attachment;
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
                var myfile= state.file_attachment;
                message.Attachments = new List<Attachment>();
                message.Attachments.Add(myfile);
                try
                {
                    await connector.Conversations.SendToConversationAsync((Activity)message);
                }
                catch (ErrorResponseException e)
                {
                    Console.WriteLine("Error: ", e.StackTrace);
                }
              
 
                var resumeSize = await RetrieveAttachmentSizeAsync(state.file_attachment);
            };
            return new FormBuilder<ImagesForm>()
                        .Message("Welcome")
                        .OnCompletion(onFormCompleted)
                        .Build();
        }
        private static async Task<long> RetrieveAttachmentSizeAsync(AwaitableAttachment attachment)
        {
            var stream = await attachment;
            return stream.Length;
        }
    }`

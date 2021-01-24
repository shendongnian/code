    [BotAuthentication]
    public class MessagesController : ApiController
    {
        internal static IDialog<object> MakeRoot()
        {
            var qnaDialog = new Dialogs.MyQnADialog
            {
                MetadataFilter = new List<Metadata>()
                {
                    new Metadata()
                    {
                        Name = "knowledgebase",
                        Value = "base1"
    
                        //Name = "knowledgebase",
                        //Value = "base2"
                    }
                }
            };
    
            return qnaDialog;
        }
    
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, MakeRoot);
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    
        //......
        // other code logic
        //......
    }

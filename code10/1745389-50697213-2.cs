    public class MessagesController : ApiController
        {
            IDialogCreator DialogCreator;
    		public MessagesController(IDialogCreator DialogCreator)
            {
                this.DialogCreator = DialogCreator;
            }
    		public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
            {
                try
                {
                    HttpResponseMessage response;
                    if (activity.Type == ActivityTypes.Message)
                    {
                        var RootDialog = DialogCreator.GetDialog("RootDialog"); or // scope.ResolveNamed<IDialog<object>>("RootDialog");
                        await Conversation.SendAsync(activity, () => RootDialog);
                    }
                    else
                    {
                        HandleSystemMessage(activity);
                    }
    		}
    	}

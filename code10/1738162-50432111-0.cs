    [Serializable]
    [LuisModel("MODEL_ID", "SUBSCRIPTION_KEY")]
    public class RootDialog : LuisDialog<object>
    {
        [LuisIntent("FindItem")]
        public async Task FindItem(IDialogContext context, LuisResult result)
        {
            var entities = result.Entities;
            var id = entities.First(x => x.Entity == "id");
            if ( id != null)
            {
                //Id entity is there, go ahead with your logic
            }
            else
            {
                //Id is not specified by user. Prompt for it.
                PromptDialog.Text(context, UserEnteredId, "Please enter the item id.");
            }
        }
        private async Task UserEnteredId(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;
            //Here message contains the id entered by user.
            //Proceed with your logic
        }
        //Rest of the logic
    }

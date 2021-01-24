    public class QnaDialog : BaseDialog
    {
        protected override async Task<bool> HandleMessageAsync(IDialogContext context, IMessageActivity message)
        {
            if (message.Text == "My name is Javier")
            {
                await context.PostAsync("What a cool name!");
                // question was answered -> end the dialog
                return true;
            }
            else
            {
                await context.PostAsync("What is your name?");
                // wait for the user response
                return false;
            }
        }
    }

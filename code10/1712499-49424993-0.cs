    [Serializable]
    public class RootDialog : IDialog<object>
    {
        string name;
        string email;
        string phone;
    
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
    
            return Task.CompletedTask;
        }
    
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
    
            if (activity.Text.ToLower().Contains("ok"))
            {
                PromptDialog.Text(
                    context: context,
                    resume: ResumeGetName,
                    prompt: "Please share your name",
                    retry: "Please try again."
                );
            }
            else
            {
                context.Done(this);
            }
    
            //context.Wait(MessageReceivedAsync);
        }
    
        public async Task ResumeGetName(IDialogContext context, IAwaitable<string> Username)
        {
            string uname = await Username;
            name = uname;
    
            PromptDialog.Text(
                context: context,
                resume: ResumeGetEmail,
                prompt: "Please share your Email",
                retry: "Please try again."
            );
        }
    
        public async Task ResumeGetEmail(IDialogContext context, IAwaitable<string> UserEmail)
        {
            string uemail = await UserEmail;
            email = uemail; 
    
            PromptDialog.Text(
                context: context,
                resume: ResumeGetPhone,
                prompt: "Please share your Phone Number",
                retry: "Please try again."
            );
        }
        public async Task ResumeGetPhone(IDialogContext context, IAwaitable<string> mobile)
        {
            string response = await mobile;
            phone = response;
    
            //in this Resume handler, you can save the data that you collected from user into your sql database
    
            await context.PostAsync($"your name:{name}, email:{email}, phonenumber: {phone}");
    
            context.Done(this);
        }
    }

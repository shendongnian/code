    [LuisIntent("Getfile")]
        public async Task GetfileIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Sure we can help you on that... ");
            await context.PostAsync("But first i need to know the purpose ");
           context.Call(new UserInteraction(),ResumeAfterFeedback);
    
        }
        private async Task ResumeAfterFeedback(IDialogContext context, IAwaitable<object> result)
        {
            var interactionResult = await result as UserInteraction;
            await context.PostAsync("Prepared an email for you");
            context.Wait(MessageReceived);
        }
    
    
        [Serializable]
        public class UserInteraction : IDialog<object>
        {
            protected string Purpose { get; set; }
            protected string ClientName { get; set; }
            protected string Teamname { get; set; }
    
            public async Task StartAsync(IDialogContext context)
            {
                await context.PostAsync("Please enter the purpose");
                context.Wait(Getuserpurpose);
    
            }
            public async Task Getuserpurpose(IDialogContext context, IAwaitable<IMessageActivity> argument)
            {
                var message = await argument;
                this.Purpose = message.Text;
                await context.PostAsync("Now please tell me the client name");
                context.Wait(Getuserclient);
    
            }
    
            private async Task Getuserclient(IDialogContext context, IAwaitable<IMessageActivity> result)
            {
                var message = await result;
                ClientName = message.Text;
                await context.PostAsync("Now please tell me Team Name");
                context.Wait(GetUserTeamName);
            }
    
            private async Task GetUserTeamName(IDialogContext context, IAwaitable<IMessageActivity> result)
            {
                var message = await result;
                Teamname = message.Text;
                await context.PostAsync("Got it");
                context.Done(this);
            }
        }

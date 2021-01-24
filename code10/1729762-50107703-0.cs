        private Task ChoiceReceivedAsync(IDialogContext context, IAwaitable<string> result)
        {
           Activity a = context.Activity as Activity;
            switch (a.Text)
            {
                case "Choice 1":
                    //do stuff
                    break;
                case "Choice 2":
                    //do stuff
                    break;
                default:
                    context.Forward(new Luis(), afterLuis, context.Activity, CancellationToken.None);
                    break;
            }
            a = a.CreateReply("things");
            context.PostAsync(a);
            return Task.CompletedTask;
        }

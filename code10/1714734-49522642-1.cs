    public class SettingsDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            ...
        }
    
        private async Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            ...
        }
    }

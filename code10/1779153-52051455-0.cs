    namespace FormBot.Dialogs
    {
        [Serializable]
        public class HardwareDialog : IDialog<object>
        {
            public async Task StartAsync(IDialogContext context)
            {
                await context.PostAsync("Welcome to the Hardware solution helpdesk!");
                var HardwareFormDialog = new FormDialog<HardwareQuery>(new HardwareQuery(), HardwareQuery.BuildForm, FormOptions.PromptInStart);
                context.Call(HardwareFormDialog, this.ResumeAfterHardwareFormDialog);
            }
        private async Task ResumeAfterHardwareFormDialog(IDialogContext context, IAwaitable<HardwareQuery> result)
        {
            try
            {
            }
            catch (FormCanceledException ex)
            {
                string reply;
                if (ex.InnerException == null)
                {
                    reply = "You have canceled the operation. Quitting from the HardwareDialog";
                }
                else
                {
                    reply = $"Oops! Something went wrong :( Technical Details: {ex.InnerException.Message}";
                }
                await context.PostAsync(reply);
            }
            finally
            {
                context.Done<object>(null);
            }
        }

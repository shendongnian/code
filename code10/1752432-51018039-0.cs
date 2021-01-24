       [Serializable]
        public class LayerDialog: IDialog<IMessageActivity>
        {
            public async Task StartAsync(IDialogContext context)
            {
                context.Wait(this.OnMessageReceivedAsync);
            }
    
        private async Task OnMessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var awaited = await result;
    
            FormStateModel model = new FormStateModel();
            model.Value = awaited.Text;
    
            var form = new FormDialog<FormStateModel >(model ,
                BuildForm , FormOptions.PromptInStart);
            context.Call(form , this.AfterResume);
        }

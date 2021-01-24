    public abstract class BaseDialog : IDialog<BaseResult>
    {
        public bool DialogForwarded { get; protected set; }
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(OnMessageReceivedAsync);
        }
        public async Task OnMessageReceivedAsync(
            IDialogContext context,
            IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            var dialogFinished = await HandleMessageAsync(context, message);
            if (DialogForwarded) return;
            if (!dialogFinished)
            {
                context.Wait(OnMessageReceivedAsync);
            }
            else
            {
                context.Done(new DefaultDialogResult());
            }
        }
        protected abstract Task<bool> HandleMessageAsync(IDialogContext context, IMessageActivity message);
        protected async Task ForwardToDialog(IDialogContext context, 
            IMessageActivity message, BaseDialog dialog)
        {
            DialogForwarded = true;
            await context.Forward(dialog, (dialogContext, result) =>
            {
                // Dialog resume callback
                // this method gets called when the child dialog calls context.Done()
                DialogForwarded = false;
                return Task.CompletedTask;
            }, message);
        }
    }

    [Serializable]
    public class FooDialog : IDialog<object>
    {
        public IList<EntityRecommendation> _entities { get; set; }
        public FooDialog(IList<EntityRecommendation> entities)
        {
            this._entities = entities;
        }
        public FooDialog()
        {}
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(this.MessageReceivedAsync);
        }
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result )
        {
            await context.PostAsync("Entity : " + _entities.First().Entity);
        }
    }

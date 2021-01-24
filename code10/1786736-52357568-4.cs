    public class IntentDetectorDialog : BaseDialog
    {
        private readonly INlpService _nlpService;
        public IntentDetectorDialog(INlpService nlpService)
        {
            _nlpService = nlpService;
        }
        protected override async Task<bool> HandleMessageAsync(IDialogContext context, IMessageActivity message)
        {
            var intentName = await _nlpService.AnalyzeAsync(message.Text);
            switch (intentName)
            {
                case "GoToQnaDialog":
                    await ForwardToDialog(context, message, new QnaDialog());
                    break;
                case "GoToGraphDialog":
                    await ForwardToDialog(context, message, new GraphDialog());
                    break;
            }
            return false;
        }
    }

    public class UtteranceAnalyzerDialog : BaseDialog
    {
        private readonly INlpService _nlpService;
        public UtteranceAnalyzerDialog(INlpService nlpService)
        {
            _nlpService = nlpService;
        }
        protected override async Task<bool> HandleMessageAsync(IDialogContext context, IMessageActivity message)
        {
            var nlpResult = await _nlpService.AnalyzeAsync(message.Text);
            switch (nlpResult)
            {
                case QnaMakerResult qnaResult:
                    await context.PostAsync(qnaResult.Answer);
                    return true;
                case LuisResult luisResult:
                    var dialog = _dialogFactory.BuildDialogByIntentName(luisResult.IntentName);
                    await ForwardToDialog(context, message, dialog);
                    break;
            }
            return false;
        }
    }

    [Export(typeof(IMyViewHost))]
    public class MyViewHost : IMyViewHost
    {
        [Import]
        public ITextEditorFactoryService TextEditorFactory { get; set; }
        public IWpfTextViewHost CreateViewHost(ITextBuffer textBuffer)
        {
            var textView = this.TextEditorFactory.CreateTextView(textBuffer);
            return this.TextEditorFactory.CreateTextViewHost(textView, true);
        }

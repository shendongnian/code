    public class NullOriginalText : OriginalText
    {
        public string OriginalText1 { get; private set; }
        public NullOriginalText()
        {
            OriginalText1 = string.Empty;
        }
    }
    public class ModelItem
    {
        public OriginalText { get; private set; }
        public ModelItem()
        {
             OriginalText = new NullOriginalText();
        }
        public ModelItem(OriginalText originalText)
        {
             if (originalText == null)
             {
                 OriginalText = new NullOriginalText();
             }
             else
             {
                 OriginalText = originalText;
             }
        }
    }
    

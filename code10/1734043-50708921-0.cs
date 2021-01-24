    public class Tag
    {
        public TextPointer StartPosition;
        public TextPointer EndPosition;
    }
    private void DescriptionText_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text;
        DescriptionText.TextChanged -= this.DescriptionText_TextChanged;
        var range = new TextRange(DescriptionText.Document.ContentStart, DescriptionText.Document.ContentEnd);
        range.ClearAllProperties();
        var tags = new List<Tag>();
        TextPointer navigator = DescriptionText.Document.ContentStart;
        while (navigator.CompareTo(DescriptionText.Document.ContentEnd) < 0)
        {
            TextPointerContext context = navigator.GetPointerContext(LogicalDirection.Backward);
            if (context == TextPointerContext.ElementStart && navigator.Parent is Run)
            {
                text = ((Run)navigator.Parent).Text;
                if (text != "")
                    tags.AddRange(CheckWordsInRun(text, (Run)navigator.Parent));
            }
            navigator = navigator.GetNextContextPosition(LogicalDirection.Forward);
        }
        foreach (Tag tag in tags)
        {
            var r = new TextRange(tag.StartPosition, tag.EndPosition);
            r.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Red));
        }
        DescriptionText.TextChanged += this.DescriptionText_TextChanged;
    }
    private List<Tag> CheckWordsInRun(string text, Run theRun)
    {
        List<Tag> m_tags = new List<Tag>();
        for (int i = 0; i < text.Length; i++)
        {
            if (Char.IsNumber(text[i]))
            {
                Tag t = new Tag();
                t.StartPosition = theRun.ContentStart.GetPositionAtOffset(i, LogicalDirection.Forward);
                t.EndPosition = theRun.ContentStart.GetPositionAtOffset(i + 1, LogicalDirection.Backward);
                m_tags.Add(t);
            }
        }
        return m_tags;
    }

    public static void HighlightText(RichTextBox richTextBox, int startPoint, int endPoint, Color color)
    {
        //Trying to highlight charactars here
        TextPointer pointer = richTextBox.Document.ContentStart;
        TextPointer start = null, end = null;
        int count = 0;
        while (pointer != null)
        {
            if (pointer.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
            {
                if (count == startPoint) start = pointer.GetInsertionPosition(LogicalDirection.Forward);
                if (count == endPoint) end = pointer.GetInsertionPosition(LogicalDirection.Forward);
                count++;
            }
            pointer = pointer.GetNextInsertionPosition(LogicalDirection.Forward);
        }
        if (start == null) start = richTextBox.Document.ContentEnd;
        if (end == null) end = richTextBox.Document.ContentEnd;
        TextRange range = new TextRange(start, end);
        range.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(color));
    }

    public static void HighlightText(RichTextBox richTextBox, int startPoint, int endPoint, Color color)
    {
        //Trying to highlight charactars here
        TextPointer pointer = richTextBox.Document.ContentStart;
        TextRange range = new TextRange(pointer.GetPositionAtOffset(startPoint), pointer.GetPositionAtOffset(endPoint));
        range.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(color));
    }

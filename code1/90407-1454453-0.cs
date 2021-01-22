    var textRange = MyRichTextBox.Selection;
    var start = MyRichTextBox.Document.ContentStart;
    var startPos = start.GetPositionAtOffset(3);
    var endPos = start.GetPositionAtOffset(8);
    textRange.Select(startPos, endPos);
    textRange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Blue));
    textRange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);

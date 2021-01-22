    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            var start = box.TextLength;
            box.AppendText(text);
            var end = box.TextLength;
            box.SelectionStart = start;
            box.SelectionLength = end - start;
            box.SelectionColor = color;
        }
    }

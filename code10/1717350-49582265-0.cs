    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, HorizontalAlignment align)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionAlignment = align;
            box.AppendText(text);
        }
    }

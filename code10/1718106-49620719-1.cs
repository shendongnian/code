    LogMessageWindow.AppendWithColor(((message & 2) == 0) ? Color.Red : Color.Green, 
                                       message.ToString() + "\n");
    public static class RTBExtensions
    {
        public static void AppendWithColor(this RichTextBox rtb, Color? color, string AppendedText)
        {
            int sLenght = AppendedText.Length;
            rtb.AppendText(AppendedText);
            rtb.Select(rtb.Text.Length - sLenght, sLenght);
            if (color != null)
                rtb.SelectionColor = (Color)color;
            rtb.ScrollToCaret();
        }
    }

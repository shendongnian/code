    static public string ConvertToText(string rtf)
    {
       RichTextBox rtb = new RichTextBox();
       rtb.Rtf = rtf;
       return rtb.Text;
    }

    static public string ConvertToText(string rtf)
    {
       using(RichTextBox rtb = new RichTextBox())
       {
           rtb.Rtf = rtf;
           return rtb.Text;
       }
    }

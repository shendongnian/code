    public static class Extension
    {
        public static void add(this System.Windows.Forms.RichTextBox richText, string line)
        {    
           richText.Text += line + '\n';
        }
    }

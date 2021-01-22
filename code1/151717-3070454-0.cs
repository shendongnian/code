    public class RichTextBoxEx :RichTextBox
    {
        public new String Rtf
        {
            get
            {
                return base.Rtf;
            }
            set
            {
                try
                {
                    // is this rtf?
                    if (Regex.IsMatch(value, @"^{\\rtf1"))
                    {
                        base.Rtf = value;
                    }
                    else
                    {
                        base.Text = value;
                    }
                }
                catch (ArgumentException) // happens if rtf content is corrupt
                {
                    base.Text = value;
                }
            }
        }
    }

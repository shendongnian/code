    using System.Globalization;
    using System.Threading;
    public void ToTitleCase(TextBox TextBoxName)
            {
                int TextLength = TextBoxName.Text.Length;
                if (TextLength == 1)
                {
                    CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                    TextInfo textInfo = cultureInfo.TextInfo;
                    TextBoxName.Text = textInfo.ToTitleCase(TextBoxName.Text);
                    TextBoxName.SelectionStart = 1;
                }
                else if (TextLength > 1 && TextBoxName.SelectionStart < TextLength)
                {
                    int x = TextBoxName.SelectionStart;
                    CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                    TextInfo textInfo = cultureInfo.TextInfo;
                    TextBoxName.Text = textInfo.ToTitleCase(TextBoxName.Text);
                    TextBoxName.SelectionStart = x;
                }
                else if (TextLength > 1 && TextBoxName.SelectionStart >= TextLength)
                {
                    CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                    TextInfo textInfo = cultureInfo.TextInfo;
                    TextBoxName.Text = textInfo.ToTitleCase(TextBoxName.Text);
                    TextBoxName.SelectionStart = TextLength;
                }
            }
    

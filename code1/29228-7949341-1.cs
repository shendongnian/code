        private void myTextBox_TextChanged(object sender, EventArgs e)
        {
            validateText(myTextBox);
        }
        private void validateText(TextBox box)
        {
            string text = box.Text;
            if (text == "")
                return;
            string validText = "";
            bool hasPeriod = false;
            int pos = box.SelectionStart;
            for (int i = 0; i < text.Length; i++ )
            {
                bool badChar = false;
                char s = text[i];
                if (s == '.')
                {
                    if (hasPeriod)
                        badChar = true;
                    else
                        hasPeriod = true;
                }
                else if (s < '0' || s > '9')
                    badChar = true;
                if (!badChar)
                    validText += s;
                else
                {
                    if (i <= pos)
                        pos--;
                }
            }
            
            // trim starting 00s
            while (validText.Length >= 2 && validText[0] == '0')
            {
                if (validText[1] != '.')
                {
                    validText = validText.Substring(1);
                    if (pos < 2)
                        pos--;
                }
                else
                    break;
            }
            if (pos > validText.Length)
                pos = validText.Length;
            box.Text = validText;
            box.SelectionStart = pos;
        }

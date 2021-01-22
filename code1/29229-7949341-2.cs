        private void validateText(TextBox box)
        {
            string text = box.Text;
            if (text == "")
                return;
            string validText = "";
            int pos = box.SelectionStart;
            for (int i = 0; i < text.Length; i++ )
            {
                char s = text[i];
                if (s < '0' || s > '9')
                {
                    if (i <= pos)
                        pos--;
                }
                else
                    validText += s;
            }
            if (pos > validText.Length)
                pos = validText.Length;
            box.Text = validText;
            box.SelectionStart = pos;
        }
 

        private void validateText(TextBox box)
        {
            // stop multiple changes;
            if (_myTextBoxChanging)
                return;
            _myTextBoxChanging = true;
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
            // trim starting 00s 
            while (validText.Length >= 2 && validText.StartsWith("00")) 
            { 
                validText = validText.Substring(1); 
                if (pos < 2) 
                    pos--; 
            } 
            if (pos > validText.Length)
                pos = validText.Length;
            box.Text = validText;
            box.SelectionStart = pos;
            _myTextBoxChanging = false;
        }
 

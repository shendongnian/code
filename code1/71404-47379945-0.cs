        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (e.KeyData == (Keys.Back | Keys.Control))
            {
                if (!box.ReadOnly && box.SelectionLength == 0)
                {
                    RemoveWord(box);
                }
                e.SuppressKeyPress = true;
            }
        }
        private void RemoveWord(TextBox box)
        {
            string text = Regex.Replace(box.Text.Substring(0, box.SelectionStart), @"(^\W)?\w*\W*$", "");
            box.Text = text + box.Text.Substring(box.SelectionStart);
            box.SelectionStart = text.Length;
        }

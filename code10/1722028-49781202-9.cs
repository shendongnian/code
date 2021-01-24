    private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            KeysConverter kc = new KeysConverter();
            char c = char.ToLower(kc.ConvertToString(e.KeyValue)[0]); 
            if (char.IsLetter(c))
            {
                //Caps? 
                if (e.Modifiers == Keys.Shift)
                {
                    c = char.ToUpper(c);
                }
                //Check, if its valid for si prefixes.
                if (this.siSelector1.TrySelect(c))
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

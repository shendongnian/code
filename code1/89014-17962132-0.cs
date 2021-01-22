        private void Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox Box = (sender as TextBox);
            if (Box.SelectionStart < Box.TextLength && !Char.IsControl(e.KeyChar))
            {
                int CacheSelectionStart = Box.SelectionStart; //Cache SelectionStart as its reset when the Text property of the TextBox is set.
                StringBuilder sb = new StringBuilder(Box.Text); //Create a StringBuilder as Strings are immutable
                sb[Box.SelectionStart] = e.KeyChar; //Add the pressed key at the right position
                Box.Text = sb.ToString(); //SelectionStart is reset after setting the text, so restore it
                Box.SelectionStart = CacheSelectionStart + 1; //Advance to the next char
            }
        }

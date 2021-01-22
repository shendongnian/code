        private void EnterKey(Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !System.Uri.IsHexDigit(e.KeyChar) && c != 0x2C;
        }

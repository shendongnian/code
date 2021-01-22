        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            {
                e.Handled = !(((TextBox)sender).SelectionStart != 0 && (e.KeyChar.ToString() == Application.CurrentCulture.NumberFormat.NumberDecimalSeparator && ((TextBox)sender).Text.IndexOf(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator) == -1));
            }
        }

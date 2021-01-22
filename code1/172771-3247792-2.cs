        private void txtType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Back || e.KeyChar == (char)'.') && !(sender as TextBox).Text.Contains("."))
            {
                return;
            }
            decimal isNumber = 0;
            e.Handled = !decimal.TryParse(e.KeyChar.ToString(), out isNumber);
        }

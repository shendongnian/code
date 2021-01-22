        private void txtType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Back || e.KeyChar == (char)'.') && !(sender as TextBox).Text.Contains("."))
            {
                return;
            }
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
        }

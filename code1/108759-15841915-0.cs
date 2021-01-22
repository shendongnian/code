        private void tbxMod_Enter(object sender, EventArgs e)
        {
            AcceptButton = null;
        }
        private void tbxMod_Leave(object sender, EventArgs e)
        {
            AcceptButton = buttonOK;
        }
        private void tbxMod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Click your button here or whatever
                e.Handled = true;
            }
        }

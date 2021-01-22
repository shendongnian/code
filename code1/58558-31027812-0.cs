        private void txtRF_Register_Val_KeyDown(object sender, KeyEventArgs e)
        {
            //only enable alphanumeric
            if (!(((e.KeyCode < Keys.NumPad0) || (e.KeyCode > Keys.NumPad9)) && ((e.KeyCode < Keys.A) || (e.KeyCode > Keys.E))))
            {
                e.SuppressKeyPress = false;
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }

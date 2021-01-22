        private void YourControl_KeyDown(object sender, KeyEventArgs e)
        { 
            if (e.KeyCode  == Keys.Menu)
            {
                //YourCode
                e.Handled = true;
            }
        }
        private void YourControl_KeyUp(object sender, KeyEventArgs e)
        { 
            if (e.KeyData == Keys.Menu)
            {
                //YourCode
                e.Handled = true;
            }
        }

     private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                if (((TextBox)sender).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
                else if (((TextBox)sender).Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
    
            if (e.KeyChar == '\b')  // backspace silme tuşunun çalıması için gerekli
            {
                e.Handled = false;
            }
    
            base.OnKeyPress(e);
        }

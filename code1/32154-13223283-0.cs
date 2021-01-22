     private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string original = (sender as TextBox).Text;
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.')
            {
                if (original.Contains('.'))
                    e.Handled = true;
                else if (!(original.Contains('.')))
                    e.Handled = false;
            }
            else if (char.IsDigit(e.KeyChar)||e.KeyChar=='\b')
            {
                e.Handled = false;
            }
            
        }

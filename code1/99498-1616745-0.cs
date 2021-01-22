    private void frmmain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Space))
                {
                     cmdPlay_Click(null, null);
                     e.Handled = true;
                }
        }

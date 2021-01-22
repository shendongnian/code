    private void textBox_KeyDown(object sender, KeyEventArgs e)
    {
         if (e.KeyCode == Keys.Enter)
         {
             button.PerformClick();
             e.SuppressKeyPress = true;
             e.Handled = true;
         }
    }

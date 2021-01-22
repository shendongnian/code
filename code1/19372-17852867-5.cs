    private void textBox_KeyDown(object sender, KeyEventArgs e)
    {
         if (e.KeyCode == Keys.Enter)
         {
             button.PerformClick();
             // these last two lines will stop the beep sound
             e.SuppressKeyPress = true;
             e.Handled = true;
         }
    }

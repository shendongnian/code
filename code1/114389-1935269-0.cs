    private void TxtBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
         if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
              e.Handled = true;
    }

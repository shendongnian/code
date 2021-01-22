    //Add to the textbox's KeyPress event
    //using Regex for number only textBox
    private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
    {
    if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
    e.Handled = true;
    }

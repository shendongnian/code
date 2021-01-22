    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        char newChar = Convert.ToChar(e.KeyValue);
        if (char.IsControl(newChar))
        {
            return;
        }
        int value;
        e.SuppressKeyPress = int.TryParse((sender as TextBox).Text + newChar.ToString(), out value) ? value == 0 : true;
    }

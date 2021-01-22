    private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (Regex.IsMatch(e.KeyChar.ToString(), @"\p{L}"))
        {
            // this is a letter
        }
        else
        {
            // this is NOT a letter
        }
    }

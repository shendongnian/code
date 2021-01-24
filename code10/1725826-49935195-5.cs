    public bool ValidateField(TextBox textBox)
    {
        if (string.IsNullOrEmpty(textBox.Text))
        {
            textBox.BackColor = Color.Red;
            return false;
        }
        else
        {
            textBox.BackColor = SystemColors.Window;
            return true;
        }
    }

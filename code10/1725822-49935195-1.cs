    public bool ValidateField(TextBox textBox)
    {
        if (string.IsNullOrEmpty(textBox.Text))
        {
            textBox.BackColor = Color.Red;
            return false;
        }
        return true;
    }

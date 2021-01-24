    public bool IsPresent(TextBox textBox, string name)
    {
        if (!string.IsNullOrEmpty(textBox.Text))
        {
             return true;
        }
        MessageBox.Show(name + " is a required field.", "Entry Error");
        textBox.Focus();
        return false;
    }

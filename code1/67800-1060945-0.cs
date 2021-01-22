    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        string text = (sender as TextBox).Text;
        StringBuilder builder = new StringBuilder(String.Empty);
        foreach (char character in text)
        {
            if (Char.IsDigit(character))
            {
                builder.Append(character);
            }
        }
        (sender as TextBox).Text = builder.ToString();
    }

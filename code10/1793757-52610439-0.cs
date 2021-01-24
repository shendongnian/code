    private void Check()
    {
        foreach (var tb in this.Controls.OfType<TextBox>())
        {
            if (String.IsNullOrEmpty(tb.Text)) tb.Hide();
            else tb.Show();
        }
    }

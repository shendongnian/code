    foreach (Control X in this.Controls)
    {
        TextBox tb = X as TextBox;
        if (tb != null)
        {
            string text = tb.Text;
            // Do something to text...
            tb.Text = string.Empty; // Clears it out...
        }
    }

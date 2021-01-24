    foreach (Panel pnl in Controls.OfType<Panel>().Where(p => p.Visible))
    {
        foreach (TextBox tb in pnl.Controls.OfType<TextBox>())
        {
            if (string.IsNullOrEmpty(tb.Text.Trim()))
            {
                MessageBox.Show("Please give an answer for all questions!");
                return;
            }
        }
    }

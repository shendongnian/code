    private void btnCheck_Click(object sender, EventArgs e) 
        {
    
            foreach (Panel pnl in Controls.OfType<Panel>())
            {
                if(!pnl.Visible) 
                   continue;
                foreach (TextBox tb in pnl.Controls.OfType<TextBox>())
                {
                    if (string.IsNullOrEmpty(tb.Text.Trim()))
                    {
                        MessageBox.Show("Please give an answer for all questions!");
                        return;
                    }
                }
    ...

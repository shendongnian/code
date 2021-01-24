        foreach (Panel pnl in Controls.OfType<Panel>())
        {
            if (pnl.Visible) {
                foreach (TextBox tb in pnl.Controls.OfType<TextBox>())
                {
                    if (string.IsNullOrEmpty(tb.Text.Trim()))
                    {
                        MessageBox.Show("Please give an answer for all questions!");
                        okFlag = false;
                        return;
                    }
                    else
                    {
                        okFlag = true;
                    }
                }
            }
        }

    private void tcExemple_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tcExemple.TabPages[e.Index];
            if (!((Control)page).Enabled)
            {
                using (SolidBrush brush = new SolidBrush(SystemColors.GrayText))
                {
                    e.Graphics.DrawString(page.Text, page.Font, brush, e.Bounds);
                }
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(page.ForeColor))
                {
                    e.Graphics.DrawString(page.Text, page.Font, brush, e.Bounds);
                }
            }
        }

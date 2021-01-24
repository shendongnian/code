     private void testToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).DisplayStyle = ToolStripItemDisplayStyle.Text;
        }
        private void testToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
        }

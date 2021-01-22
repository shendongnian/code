        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl.TabPageCollection pages = tabControl1.TabPages;
            foreach (TabPage page in pages)
            {
                saveToolStripMenuItem_Click(sender, e);
                closeTabToolStripMenuItem_Click(sender, e);
            }
                
        }

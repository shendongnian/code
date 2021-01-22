            private void closeAllOtherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.tabControl1.TabCount; i++)
                if (i != tabControl1.SelectedIndex)
                    tabControl1.TabPages.RemoveAt(i--);
        }

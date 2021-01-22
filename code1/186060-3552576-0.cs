        private void tabControl1_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                for (int tab = 0; tab < tabControl1.TabCount; ++tab) {
                    if (tabControl1.GetTabRect(tab).Contains(e.Location)) {
                        tabControl1.SelectedIndex = tab;
                        break;
                    }
                }
            }
        }

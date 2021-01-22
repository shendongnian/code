        private void lvListView_MouseClick(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            ListViewItem lvi;
            if (e.X > lv.Columns[0].Width)
            {
                lvi = null;
            }
            else
            {
                lvi = lv.GetItemAt(e.X, e.Y);
            }
            if (lvi != null)
            {
                lvi.Checked = !lvi.Checked;
                lv.Invalidate(lvi.Bounds);
            }
        }

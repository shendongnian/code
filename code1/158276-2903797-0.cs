        private void listView1_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                var loc = listView1.HitTest(e.Location);
                if (loc.Item != null) contextMenuStrip1.Show(listView1, e.Location);
            }
        }

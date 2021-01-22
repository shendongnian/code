        Point dragStart;
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Left) dragStart = e.Location;
        }
        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                var min = SystemInformation.DoubleClickSize;
                if (Math.Abs(e.X - dragStart.X) >= min.Width ||
                    Math.Abs(e.Y - dragStart.Y) >= min.Height) {
                    // Call DoDragDrop
                    //...
                }
            }
        }

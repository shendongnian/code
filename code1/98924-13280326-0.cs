    class GridToy {
        private DataGridView grid;
        public GridToy(DataGridView dgv) {
            grid = dgv;
            grid.RowHeadersWidthChanged += AdjustWidth; // Event handler.
            Layout();
        }
        public void Layout() {
            // Just do some arbitrary manipulation of the grid.
            grid.TopLeftHeaderCell.Value = "Some Arbitrary Title";
        }
        public void AdjustWidth() {
            Control horizontal = grid.Controls[0]; // Horizontal scroll bar.
            Control vertical = grid.Controls[1]; // Vertical scroll bar.
            grid.Width = grid.PreferredSize.Width - vertical.Width + 1;
            grid.Height = grid.PreferredSize.Height - horizontal.Height + 1;
        }
    }

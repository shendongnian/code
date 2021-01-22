    class MyDataGridView : DataGridView
    {
        private int mMousedOverColumnIndex = int.MinValue;
        private int mMousedOverRowIndex = int.MinValue;
        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            mMousedOverColumnIndex = e.ColumnIndex;
            mMousedOverRowIndex = e.RowIndex;
            base.OnCellMouseEnter(e);
            base.Refresh();
        }
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            if (((e.ColumnIndex == mMousedOverColumnIndex) && (e.RowIndex == -1)) ||
                ((e.ColumnIndex == -1) && (e.RowIndex == mMousedOverRowIndex)))
            {
                PaintColumnHeader(e, System.Drawing.Color.Red);
            }
            base.OnCellPainting(e);
        }
        private void PaintColumnHeader(System.Windows.Forms.DataGridViewCellPaintingEventArgs e, System.Drawing.Color color)
        {
            LinearGradientBrush backBrush = new LinearGradientBrush(new System.Drawing.Point(0, 0), new System.Drawing.Point(100, 100), color, color);
            e.Graphics.FillRectangle(backBrush, e.CellBounds);
            DataGridViewPaintParts parts = (DataGridViewPaintParts.All & ~DataGridViewPaintParts.Background);
            e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
            e.Paint(e.ClipBounds, parts);
            e.Handled = true;
        }
    }

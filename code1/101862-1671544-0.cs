    private const int RowCount = 10;
    private DataTable _table;  // updated elsewhere
    private void OnPaint(Object sender, PaintEventArgs e) {
        if (! this.DesignMode) {
            DrawTable(e.Graphics);
        }
    }
    private void DrawTable(Graphics gfx) {
        SolidBrush brush = new SolidBrush(this.ForeColor);
        for (int rownum = 0; rownum < RowCount; rownum++) {
            RectangleF rect = GetRowBounds(rownum);
            DrawRowNumber(gfx, rect, rownum);
            if (_table.Rows.Count > rownum) {
                DataRow data = _table.Rows[rownum];
                DrawName(gfx, rect, Convert.ToString(data["name"]));
                DrawCount(gfx, rect, Convert.ToSingle(data["count"]));
            }
        }
    }
    private void DrawRowNumber(Graphics gfx, RectangleF bounds, int place) {
        String str = String.Format("{0}.", (place + 1));
        SolidBrush brush = new SolidBrush(this.ForeColor);
        gfx.DrawString(str, this.Font, brush, bounds.Location);
    }
    private void DrawName(Graphics gfx, RectangleF bounds, String name) {
        PointF loc = new PointF(80, bounds.Top);
        SolidBrush brush = new SolidBrush(this.ForeColor);
        gfx.DrawString(name, this.Font, brush, loc);
    }
    private void DrawCount(Graphics gfx, RectangleF bounds, float score) {
        SolidBrush brush = new SolidBrush(this.ForeColor);
        String str = score.ToString("N1");
        SizeF size = gfx.MeasureString(str, this.Font);
        float offset = bounds.Right - size.Width;
        PointF loc = new PointF(offset, bounds.Top);
        gfx.DrawString(str, this.Font, brush, loc);
    }
    private RectangleF GetRowBounds(int row) {
        if ((row < 0) || (row >= RowCount)) {
            return RectangleF.Empty;
        }
        Rectangle bounds = this.ClientRectangle;
        float height = (float) bounds.Height / (float) RowCount;
        PointF loc = new PointF(bounds.Left, height * row);
        SizeF size = new SizeF(bounds.Width, height);
        return new RectangleF(loc, size);
    }

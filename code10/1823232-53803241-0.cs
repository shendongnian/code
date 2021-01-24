    var specificColumn = 1;
    dataGridView1.Columns[specificColumn].DefaultCellStyle.Padding = new Padding(10);
    dataGridView1.RowTemplate.Height = 45;
    dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
    dataGridView1.RowHeadersVisible = false;
    dataGridView1.CellPainting += (obj, args) =>
    {
        if (args.ColumnIndex < 0 || args.RowIndex < 0)
            return;
        args.Paint(args.CellBounds, DataGridViewPaintParts.All & 
            ~DataGridViewPaintParts.ContentForeground);
        var r = args.CellBounds;
        using (var pen = new Pen(Color.Black))
        {
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            args.Graphics.DrawLine(pen, r.Left, r.Top, r.Right, r.Top);
            args.Graphics.DrawLine(pen, r.Left, r.Bottom, r.Right, r.Bottom);
        }
        r.Inflate(-8, -8);
        if (args.ColumnIndex == specificColumn)
            TextBoxRenderer.DrawTextBox(args.Graphics, r, $"{args.FormattedValue}",
                args.CellStyle.Font, System.Windows.Forms.VisualStyles.TextBoxState.Normal);
        else
            args.Paint(args.CellBounds, DataGridViewPaintParts.ContentForeground);
        args.Handled = true;
    };

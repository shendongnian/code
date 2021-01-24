    using System.Drawing;
    using System.Windows.Forms;
    public class DataGridViewAllocationControlColumn : DataGridViewButtonColumn
    {
        public DataGridViewAllocationControlColumn()
        {
            this.CellTemplate = new DataGridViewAllocationControlCell();
        }
        public string LabelText { get; set; }
        public string ButtonText { get; set; }
        public override object Clone()
        {
            var c = (DataGridViewAllocationControlColumn)base.Clone();
            c.LabelText = this.LabelText;
            c.ButtonText = this.ButtonText;
            return c;
        }
    }
    public class DataGridViewAllocationControlCell : DataGridViewButtonCell
    {
        protected override void Paint(Graphics graphics, Rectangle clipBounds,
            Rectangle cellBounds, int rowIndex, 
            DataGridViewElementStates elementState,
            object value, object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            var g = this.DataGridView;
            var c = (DataGridViewAllocationControlColumn)this.OwningColumn;
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState,
                value, formattedValue, errorText, cellStyle, advancedBorderStyle,
                DataGridViewPaintParts.All &
                ~DataGridViewPaintParts.ContentBackground &
                ~DataGridViewPaintParts.ContentForeground);
            var r1 = g.GetCellDisplayRectangle(c.Index, rowIndex, false);
            var r2 = GetContentBounds(rowIndex);
            var r3 = new Rectangle(r1.Location, new Size(GetLabelWidth(), r1.Height));
            r2.Offset(r1.Location);
            base.Paint(graphics, clipBounds, r2, rowIndex, elementState,
                value, c.ButtonText, errorText, cellStyle, advancedBorderStyle,
                DataGridViewPaintParts.All);
            TextRenderer.DrawText(graphics, c.LabelText, cellStyle.Font,
                r3, cellStyle.ForeColor);
        }
        protected override Rectangle GetContentBounds(Graphics graphics, 
            DataGridViewCellStyle cellStyle, int rowIndex)
        {
            var w = GetLabelWidth();
            var r = base.GetContentBounds(graphics, cellStyle, rowIndex);
            return new Rectangle(r.Left + w, r.Top, r.Width - w, r.Height);
        }
        protected override void OnContentClick(DataGridViewCellEventArgs e)
        {
            base.OnContentClick(e);
            var g = this.DataGridView;
            var c = (DataGridViewAllocationControlColumn)this.OwningColumn;
            var r1 = GetContentBounds(e.RowIndex);
            var r2 = g.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            var p = new Point(r2.Left + r1.Left, r2.Top + r1.Bottom);
            if (c.ContextMenuStrip != null)
                c.ContextMenuStrip.Show(g, p);
        }
        private int GetLabelWidth()
        {
            var c = (DataGridViewAllocationControlColumn)this.OwningColumn;
            var text = c.LabelText;
            return TextRenderer.MeasureText(text, c.DefaultCellStyle.Font).Width;
        }
    }

    public class DataGridExtendedTextBoxColumn : DataGridTextBoxColumn
    {
        // I use the Form to store Brushes and the Font, feel free to handle it differently.
        Form1 parent;
        public DataGridExtendedTextBoxColumn(Form1 parent)
        {
            this.parent = parent;
        }
        // You'll need to override the paint method
        // The easy way: only change fore-/backBrush
        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            base.Paint(g, bounds, source, rowNum, parent.redBrush, parent.fontBrush, alignToRight);
        }
    }

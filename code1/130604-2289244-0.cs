    public class MyListView : ListView
    {
        private Brush m_brush;
        private Pen m_pen;
        public MyListView()
        {
            this.OwnerDraw = true;
            m_brush = new SolidBrush(Color.Blue);
            m_pen = new Pen(m_brush)
        }
        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }
        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex != 1) {
                e.DrawDefault = true;
                return;
            }
            // Draw the item's background.
            e.DrawBackground();
            var textSize = e.Graphics.MeasureString(e.SubItem.Text, e.SubItem.Font);
            var textY = e.Bounds.Y + ((e.Bounds.Height - textSize.Height) / 2);
            int textX = e.SubItem.Bounds.Location.X;
            var lineY = textY + textSize.Height;
            // Do the drawing of the underlined text.
            e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, m_brush, textX, textY);
            e.Graphics.DrawLine(m_pen, textX, lineY, textX + textSize.Width, lineY);
        }
    }

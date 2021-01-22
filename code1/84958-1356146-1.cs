    public class ListBoxEx : ListBox
    {
        public ListBoxEx()
        {
            TextBox.Visible = false;
            Controls.Add(TextBox);
        }
        private readonly Size TextBoxOffset = new Size(16, 16);
        private const Int32 CellHeight = 40;
        private readonly TextBox TextBox = new TextBox();
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            TextBox.Visible = SelectedIndex != -1;
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            // Somehow necessary
            e.Graphics.FillRectangle(new SolidBrush(BackColor), e.Bounds);
            // Drawing the item's text
            e.Graphics.DrawString(Items[e.Index].ToString(), Font, new SolidBrush(ForeColor), e.Bounds);
            // Drawing the item's borders
            e.Graphics.DrawRectangle(new Pen(ForeColor), e.Bounds);
            
            // Drawing updating the TextBox location 
            if (SelectedIndex != -1)
                TextBox.Location = Point.Add(GetItemRectangle(SelectedIndex).Location, TextBoxOffset);
            // Because clicking the scrollbar sometimes cause the ListBox to hide the TextBox
            TextBox.BringToFront();
            // Making sure the TextBox is redrawn ASAP
            TextBox.Invalidate();
        }
        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);
            e.ItemHeight = CellHeight;
        }
    }

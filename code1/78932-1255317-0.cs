    public class IconizedCheckedListBox : ListBox
    {
        public IconizedCheckedListBox()
            : base()
        {
            DrawMode = DrawMode.OwnerDrawVariable;
            DoubleBuffered = true;
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (SolidBrush b = new SolidBrush(BackColor))
                g.FillRectangle(b, e.Bounds);
            //e.DrawBackground();
            //e.DrawFocusRectangle();
            if (e.Index < Items.Count && e.Index != -1)
            {
                IconizedCheckedListBoxItem item = (IconizedCheckedListBoxItem)Items[e.Index];
                Rectangle checkBounds = e.Bounds;
                checkBounds.X += kCheckboxPadding;
                checkBounds.Y += (checkBounds.Height - kCheckboxSize) / 2;
                checkBounds.Width = kCheckboxSize;
                checkBounds.Height = kCheckboxSize;
                CheckBoxRenderer.DrawCheckBox(g, checkBounds.Location, 
                    item.Checked?CheckBoxState.CheckedNormal:CheckBoxState.UncheckedNormal);
                using (SolidBrush b = new SolidBrush(ForeColor))
                {
                    StringFormat format = new StringFormat();
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Near;
                    Rectangle textBounds = e.Bounds;
                    textBounds.X += item.Icon.Width + 2*kCheckboxPadding + kCheckboxSize;
                    textBounds.Y += 1;
                    textBounds.Width -= item.Icon.Width;
                    textBounds.Height -= 1;
                    Font f;
                    if (item.Checked)
                        f = new Font(Font, FontStyle.Bold);
                    else
                        f = Font;
                    g.DrawString(item.Data.ToString(), f, b, textBounds, format);
                }
                Image icon;
                if (!item.Checked)
                    icon = Utilities.Utilities.WashOutImage(item.Icon);
                else
                    icon = item.Icon;
                g.DrawImage(icon, e.Bounds.X + 2 * kCheckboxPadding + kCheckboxSize, e.Bounds.Y);
            }
        }
        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            e.ItemHeight = kItemHeight;
        }
        protected override void  OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int idx = IndexFromPoint(e.Location);
                if (idx != -1)
                {
                    IconizedCheckedListBoxItem item = (IconizedCheckedListBoxItem)Items[idx];
                    item.Checked = !item.Checked;
                    if (ItemCheck != null)
                    {
                        ItemCheckEventArgs args = new ItemCheckEventArgs(
                            idx,
                            item.Checked ? CheckState.Checked : CheckState.Unchecked,
                            CheckState.Indeterminate);
                        ItemCheck(this, args);
                    }
                    Invalidate();
                }
            }
            base.OnMouseClick(e);
        }
        /// <summary>
        /// This is called AFTER the check state has been updated
        /// </summary>
        public event ItemCheckEventHandler ItemCheck;
        private const int kItemHeight = 32;
        private const int kCheckboxSize = 13;
        private const int kCheckboxPadding = 4;
    }
    public class IconizedCheckedListBoxItem
    {
        public IconizedCheckedListBoxItem(Image inIcon, object inData)
        {
            Icon = inIcon;
            Data = inData;
            Checked = false;
        }
        public override string ToString()
        {
            return Data.ToString();
        }
        public Image Icon;
        public object Data;
        public bool Checked;
    }

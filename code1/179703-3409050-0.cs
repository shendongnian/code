    using System;
    using System.Drawing;
    using System.Windows.Forms;
    class RadioList : ListBox {
        public event EventHandler SelectedOptionChanged;
    
        public RadioList() {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.ItemHeight += 2;
        }
        public int SelectedOption {
            // Current item with the selected radio button
            get { return mSelectedOption; }
            set { 
                if (value != mSelectedOption) {
                    Invalidate(GetItemRectangle(mSelectedOption));
                    mSelectedOption = value; 
                    OnSelectedOptionChanged(EventArgs.Empty);
                    Invalidate(GetItemRectangle(value));
                }
            }
        }
        protected virtual void OnSelectedOptionChanged(EventArgs e) {
            // Raise SelectOptionChanged event
            EventHandler handler = this.SelectedOptionChanged;
            if (handler != null) handler(this, e);
        }
        protected override void OnDrawItem(DrawItemEventArgs e) {
            // Draw item with radio button
            using (var br = new SolidBrush(this.BackColor))
                e.Graphics.FillRectangle(br, e.Bounds);
            if (e.Index < this.Items.Count) {
                Rectangle rc = new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Height, e.Bounds.Height);
                ControlPaint.DrawRadioButton(e.Graphics, rc,
                    e.Index == SelectedOption ? ButtonState.Checked : ButtonState.Normal);
                rc = new Rectangle(rc.Right, e.Bounds.Top, e.Bounds.Width - rc.Right, e.Bounds.Height);
                TextRenderer.DrawText(e.Graphics, this.Items[e.Index].ToString(), this.Font, rc, this.ForeColor, TextFormatFlags.Left);
            }
            if ((e.State & DrawItemState.Focus) != DrawItemState.None) e.DrawFocusRectangle();
        }
        protected override void OnMouseUp(MouseEventArgs e) {
            // Detect clicks on the radio button
            int index = this.IndexFromPoint(e.Location);
            if (index >= 0 && e.X < this.ItemHeight) SelectedOption = index;
            base.OnMouseUp(e);
        }
        protected override void OnKeyDown(KeyEventArgs e) {
            // Turn on option with space bar
            if (e.KeyData == Keys.Space && this.SelectedIndex >= 0) SelectedOption = this.SelectedIndex;
            base.OnKeyDown(e);
        }
        private int mSelectedOption;
    }

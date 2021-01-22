    public class ListViewMultiSelect : ListView
    {
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_RBUTTONDOWN = 0x0204;
        private int _multiSelectionLimit;
        /// <summary>
        /// The limit to how many items that can be selected simultaneously. Set value to zero for unlimited selections.
        /// </summary>
        public int MultiSelectionLimit
        {
            get
            {
                return this._multiSelectionLimit;
            }
            set
            {
                this._multiSelectionLimit = Math.Max(value, 0);
            }
        }
        public ListViewMultiSelect()
        {
            this.SelectedIndexChanged += new EventHandler(ListViewMultiSelect_SelectedIndexChanged);
        }
        public ListViewMultiSelect(int selectionsLimit)
            : this()
        {
            this.MultiSelectionLimit = selectionsLimit;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_LBUTTONDOWN:
                    if (this.SelectedItems.Count == 0 || !this.MultiSelect) { break; }
                    int x = (m.LParam.ToInt32() & 0xffff);
                    int y = (m.LParam.ToInt32() >> 16) & 0xffff;
                    ListViewHitTestInfo hitTest = this.HitTest(x, y);
                    if (hitTest != null && hitTest.Item != null) { hitTest.Item.Selected = !hitTest.Item.Selected; }
                    this.Focus();
                    return;
                case WM_RBUTTONDOWN:
                    if (this.SelectedItems.Count > 0) { this.SelectedItems.Clear(); }
                    break;
            }
            base.WndProc(ref m);
        }
        void ListViewMultiSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.MultiSelectionLimit > 0 && this.SelectedItems.Count > this.MultiSelectionLimit) { this.SelectedItems.Clear(); }
        }
    }

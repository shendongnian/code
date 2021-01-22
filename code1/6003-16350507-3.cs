    public class ListViewMultiSelect : ListView
    {
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_RBUTTONDOWN = 0x0204;
        private bool _selectionsBeingCleared;
        /// <summary>
        /// Returns a boolean indicating if multiple items are being deselected.
        /// </summary>
        /// <remarks> This value can be used to avoid updating through events before all deselections have been carried out.</remarks>
        public bool SelectionsBeingCleared
        {
            get
            {
                return this._selectionsBeingCleared;
            }
            private set
            {
                this._selectionsBeingCleared = value;
            }
        }
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
            this.ItemSelectionChanged += this.multiSelectionListView_ItemSelectionChanged;
        }
        public ListViewMultiSelect(int selectionsLimit)
            : this()
        {
            this.MultiSelectionLimit = selectionsLimit;
        }
        private void multiSelectionListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                if (this.MultiSelectionLimit > 0 && this.SelectedItems.Count > this.MultiSelectionLimit)
                {
                    this._selectionsBeingCleared = true;
                    List<ListViewItem> itemsToDeselect = this.SelectedItems.Cast<ListViewItem>().Except(new ListViewItem[] { e.Item }).ToList();
                    foreach (ListViewItem item in itemsToDeselect.Skip(1)) { 
                        item.Selected = false; 
                    }
                    this._selectionsBeingCleared = false;
                    itemsToDeselect[0].Selected = false;
                }
            }
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_LBUTTONDOWN:
                    if (this.SelectedItems.Count == 0 || !this.MultiSelect) { break; }
                    if (this.MultiSelectionLimit > 0 && this.SelectedItems.Count > this.MultiSelectionLimit) { this.ClearSelections(); }
                    int x = (m.LParam.ToInt32() & 0xffff);
                    int y = (m.LParam.ToInt32() >> 16) & 0xffff;
                    ListViewHitTestInfo hitTest = this.HitTest(x, y);
                    if (hitTest != null && hitTest.Item != null) { hitTest.Item.Selected = !hitTest.Item.Selected; }
                    this.Focus();
                    return;
                case WM_RBUTTONDOWN:
                    if (this.SelectedItems.Count > 0) { this.ClearSelections(); }
                    break;
            }
            base.WndProc(ref m);
        }
        private void ClearSelections()
        {
            this._selectionsBeingCleared = true;
            SelectedListViewItemCollection itemsToDeselect = this.SelectedItems;
            foreach (ListViewItem item in itemsToDeselect.Cast<ListViewItem>().Skip(1)) { 
                item.Selected = false; 
            }
            this._selectionsBeingCleared = false;
            this.SelectedItems.Clear();
        }
    }

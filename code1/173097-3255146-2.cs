    public class CustomListView : ListView
    {
        protected CustomListView()
        {
            this.SelectedIndexChanged += new EventHandler(CustomListView_SelectedIndexChanged);
            this.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(CustomListView_ItemSelectionChanged);
        }
        void CustomListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.MaintainLastSelection && listView1.SelectedIndices.Count == 0)
            {
                if (_previousIndex >= 0)
                {
                    listView1.SelectedIndices.Add(_previousIndex);
                }
            }
        }
        void CustomListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                _previousIndex = e.ItemIndex;
            }
        }
        public bool MaintainLastSelection
        {
            get { return _maintainLastSelection; }
            set { _maintainLastSelection = value; }
        }
        private bool _maintainLastSelection;
    }

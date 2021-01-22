    public class FilterBindingListAdapter<T> : BindingList<T>, IBindingListView
    {
        protected string filter = String.Empty;
        protected IBindingList bindingList;
        private bool filtering = false;
        public FilterBindingListAdapter(IBindingList bindingList)
        {
            this.bindingList = bindingList;
            DoFilter();
        }
        
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (!filtering)
            {
                switch (e.ListChangedType)
                {
                    case ListChangedType.ItemAdded:
                        bindingList.Insert(e.NewIndex, this[e.NewIndex]);
                        break;
                }
            }
            base.OnListChanged(e);
        }
        protected override void RemoveItem(int index)
        {
            if (!filtering)
            {
                bindingList.RemoveAt(index);
            }
            base.RemoveItem(index);
        }
        protected virtual void DoFilter()
        {
            filtering = true;
            this.Clear();
            foreach (T e in bindingList)
            {
                if (filter.Length == 0 || this.ISVisible(e))
                {
                    this.Add((T)e);
                }
            }
            filtering = false;
        }
        protected virtual bool ISVisible(T element)
        {
            return true;
        }
        #region IBindingListView Members
        public void ApplySort(ListSortDescriptionCollection sorts)
        {
            throw new NotImplementedException();
        }
        public string Filter
        {
            get
            {
                return filter;
            }
            set
            {
                filter = value;
                DoFilter();
            }
        }
        public void RemoveFilter()
        {
            Filter = String.Empty;
        }
        public ListSortDescriptionCollection SortDescriptions
        {
            get { throw new NotImplementedException(); }
        }
        public bool SupportsAdvancedSorting
        {
            get { return false; }
        }
        public bool SupportsFiltering
        {
            get { return true; }
        }
        #endregion
    }

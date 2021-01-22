    class MyCustomSortingDataSource : FastObjectListDataSource
    {
        public MyCustomSortingDataSource(FastObjectListView listView)
            : base(listView) { }
        public OLVColumn SortColumn {
            get { return this.sortColumn; }
            set { this.sortColumn = value; }
        }
        private OLVColumn sortColumn;
        public override void Sort(OLVColumn column, SortOrder sortOrder)
        {
            if (sortOrder != SortOrder.None) {
                ArrayList objects = (ArrayList)this.listView.Objects;
                objects.Sort(new ModelObjectComparer(this.SortColumn, SortOrder.Ascending, column, sortOrder));
            }
            this.RebuildIndexMap();
        }
    }

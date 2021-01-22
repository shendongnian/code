    public class GridViewColumnCollectionBehaviour
    {
        private object columnsSource;
        private GridView gridView;
        public GridViewColumnCollectionBehaviour(GridView gridView)
        {
            this.gridView = gridView;
        }
        public object ColumnsSource
        {
            get { return this.columnsSource; }
            set
            {
                object oldValue = this.columnsSource;
                this.columnsSource = value;
                this.ColumnsSourceChanged(oldValue, this.columnsSource);
            }
        }
        public string DisplayMemberFormatMember { get; set; }
        public string DisplayMemberMember { get; set; }
        public string HeaderTextMember { get; set; }
        public string WidthMember { get; set; }
        private void AddHandlers(ICollectionView collectionView)
        {
            collectionView.CollectionChanged += this.ColumnsSource_CollectionChanged;
        }
        private void ColumnsSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ICollectionView view = sender as ICollectionView;
            if (this.gridView == null)
            {
                return;
            }
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        GridViewColumn column = CreateColumn(e.NewItems[i]);
                        gridView.Columns.Insert(e.NewStartingIndex + i, column);
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    List<GridViewColumn> columns = new List<GridViewColumn>();
                    for (int i = 0; i < e.OldItems.Count; i++)
                    {
                        GridViewColumn column = gridView.Columns[e.OldStartingIndex + i];
                        columns.Add(column);
                    }
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        GridViewColumn column = columns[i];
                        gridView.Columns.Insert(e.NewStartingIndex + i, column);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    for (int i = 0; i < e.OldItems.Count; i++)
                    {
                        gridView.Columns.RemoveAt(e.OldStartingIndex);
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        GridViewColumn column = CreateColumn(e.NewItems[i]);
                        gridView.Columns[e.NewStartingIndex + i] = column;
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    gridView.Columns.Clear();
                    CreateColumns(sender as ICollectionView);
                    break;
                default:
                    break;
            }
        }
        private void ColumnsSourceChanged(object oldValue, object newValue)
        {
            if (this.gridView != null)
            {
                gridView.Columns.Clear();
                if (oldValue != null)
                {
                    ICollectionView view = CollectionViewSource.GetDefaultView(oldValue);
                    if (view != null)
                    {
                        this.RemoveHandlers(view);
                    }
                }
                if (newValue != null)
                {
                    ICollectionView view = CollectionViewSource.GetDefaultView(newValue);
                    if (view != null)
                    {
                        this.AddHandlers(view);
                        this.CreateColumns(view);
                    }
                }
            }
        }
        private GridViewColumn CreateColumn(object columnSource)
        {
            GridViewColumn column = new GridViewColumn();
            if (!string.IsNullOrEmpty(this.HeaderTextMember))
            {
                column.Header = GetPropertyValue(columnSource, this.HeaderTextMember);
            }
            if (!string.IsNullOrEmpty(this.DisplayMemberMember))
            {
                string propertyName = GetPropertyValue(columnSource, this.DisplayMemberMember) as string;
                string format = null;
                if (!string.IsNullOrEmpty(this.DisplayMemberFormatMember))
                {
                    format = GetPropertyValue(columnSource, this.DisplayMemberFormatMember) as string;
                }
                if (string.IsNullOrEmpty(format))
                {
                    format = "{0}";
                }
                column.DisplayMemberBinding = new Binding(propertyName) { StringFormat = format };
            }
            if (!string.IsNullOrEmpty(this.WidthMember))
            {
                double width = (double)GetPropertyValue(columnSource, this.WidthMember);
                column.Width = width;
            }
            return column;
        }
        private void CreateColumns(ICollectionView collectionView)
        {
            foreach (object item in collectionView)
            {
                GridViewColumn column = this.CreateColumn(item);
                this.gridView.Columns.Add(column);
            }
        }
        private object GetPropertyValue(object obj, string propertyName)
        {
            object returnVal = null;
            if (obj != null)
            {
                PropertyInfo prop = obj.GetType().GetProperty(propertyName);
                if (prop != null)
                {
                    returnVal = prop.GetValue(obj, null);
                }
            }
            return returnVal;
        }
        private void RemoveHandlers(ICollectionView collectionView)
        {
            collectionView.CollectionChanged -= this.ColumnsSource_CollectionChanged;
        }
    }

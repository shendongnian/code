    public class CustomDataGrid : DataGrid
    {
        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
            INotifyCollectionChanged oldView = oldValue as INotifyCollectionChanged;
            if (oldView != null)
                oldView.CollectionChanged -= View_CollectionChanged;
            INotifyCollectionChanged newView = newValue as INotifyCollectionChanged;
            if (newView != null)
                newView.CollectionChanged += View_CollectionChanged;
        }
        private void View_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ICollectionView view = sender as ICollectionView;
            if (view != null)
            {
                SortDescription sd = view.SortDescriptions.LastOrDefault();
                if (sd != null)
                {
                    DataGridColumn column = Columns.FirstOrDefault(x => x.SortMemberPath == sd.PropertyName);
                    if (column != null)
                    {
                        column.SortDirection = sd.Direction;
                    }
                }
            }
        }
    }

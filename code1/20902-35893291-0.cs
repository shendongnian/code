    public class DataGridColumnsBehavior
    {
        public static readonly DependencyProperty BindableColumnsProperty =
            DependencyProperty.RegisterAttached("BindableColumns",
                                                typeof(ObservableCollection<DataGridColumn>),
                                                typeof(DataGridColumnsBehavior),
                                                new UIPropertyMetadata(null, BindableColumnsPropertyChanged));
        /// <summary>Collection to store collection change handlers - to be able to unsubscribe later.</summary>
        private static readonly Dictionary<DataGrid, NotifyCollectionChangedEventHandler> _handlers;
        static DataGridColumnsBehavior()
        {
            _handlers = new Dictionary<DataGrid, NotifyCollectionChangedEventHandler>();
        }
        private static void BindableColumnsPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            DataGrid dataGrid = source as DataGrid;
            ObservableCollection<DataGridColumn> oldColumns = e.OldValue as ObservableCollection<DataGridColumn>;
            if (oldColumns != null)
            {
                // Remove all columns.
                dataGrid.Columns.Clear();
                // Unsubscribe from old collection.
                NotifyCollectionChangedEventHandler h;
                if (_handlers.TryGetValue(dataGrid, out h))
                {
                    oldColumns.CollectionChanged -= h;
                    _handlers.Remove(dataGrid);
                }
            }
            ObservableCollection<DataGridColumn> newColumns = e.NewValue as ObservableCollection<DataGridColumn>;
            dataGrid.Columns.Clear();
            if (newColumns != null)
            {
                // Add columns from this source.
                foreach (DataGridColumn column in newColumns)
                    dataGrid.Columns.Add(column);
                // Subscribe to future changes.
                NotifyCollectionChangedEventHandler h = (_, ne) => OnCollectionChanged(ne, dataGrid);
                _handlers[dataGrid] = h;
                newColumns.CollectionChanged += h;
            }
        }
        static void OnCollectionChanged(NotifyCollectionChangedEventArgs ne, DataGrid dataGrid)
        {
            switch (ne.Action)
            {
                case NotifyCollectionChangedAction.Reset:
                    dataGrid.Columns.Clear();
                    foreach (DataGridColumn column in ne.NewItems)
                        dataGrid.Columns.Add(column);
                    break;
                case NotifyCollectionChangedAction.Add:
                    foreach (DataGridColumn column in ne.NewItems)
                        dataGrid.Columns.Add(column);
                    break;
                case NotifyCollectionChangedAction.Move:
                    dataGrid.Columns.Move(ne.OldStartingIndex, ne.NewStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (DataGridColumn column in ne.OldItems)
                        dataGrid.Columns.Remove(column);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    dataGrid.Columns[ne.NewStartingIndex] = ne.NewItems[0] as DataGridColumn;
                    break;
            }
        }
        public static void SetBindableColumns(DependencyObject element, ObservableCollection<DataGridColumn> value)
        {
            element.SetValue(BindableColumnsProperty, value);
        }
        public static ObservableCollection<DataGridColumn> GetBindableColumns(DependencyObject element)
        {
            return (ObservableCollection<DataGridColumn>)element.GetValue(BindableColumnsProperty);
        }
    }

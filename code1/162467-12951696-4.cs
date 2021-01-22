    public class DataGridExtender : Behavior<XamDataGrid>
    {
        public readonly static DependencyProperty SelectedDataItemsProperty
            = DependencyProperty.Register(
                "SelectedDataItems",
                typeof(ICollection<object>),
                typeof(DataGridExtender),
                new PropertyMetadata());
        public ICollection<object> SelectedDataItems
        {
            get { return (ICollection<object>)GetValue(SelectedDataItemsProperty); }
            set { SetValue(SelectedDataItemsProperty, value); }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectedItemsChanged += AssociatedObjectOnSelectedItemsChanged;
            AssociatedObjectOnSelectedItemsChanged(AssociatedObject, null);
        }
        protected override void OnDetaching()
        {
            AssociatedObject.SelectedItemsChanged -= AssociatedObjectOnSelectedItemsChanged;
            base.OnDetaching();
        }
        private void AssociatedObjectOnSelectedItemsChanged(object sender, Infragistics.Windows.DataPresenter.Events.SelectedItemsChangedEventArgs e)
        {
            if (SelectedDataItems != null)
            {
                SelectedDataItems.Clear();
                foreach (var selectedDataItem in GetSelectedDataItems())
                {
                    SelectedDataItems.Add(selectedDataItem);
                }
            }
        }
        private IEnumerable<object> GetSelectedDataItems()
        {
            var selectedItems = from rec in AssociatedObject.SelectedItems.Records.OfType<DataRecord>() select rec.DataItem;
            return selectedItems.ToList().AsReadOnly();
        }
    }

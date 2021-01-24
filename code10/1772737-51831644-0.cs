    public class MultipleSelectionListBox : ListBox
    {
        internal bool processSelectionChanges = false;
        public static readonly DependencyProperty BindableSelectedItemsProperty =
            DependencyProperty.Register("BindableSelectedItems",
                typeof(object), typeof(MultipleSelectionListBox),
                new FrameworkPropertyMetadata(default(ICollection<object>),
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnBindableSelectedItemsChanged));
        public dynamic BindableSelectedItems
        {
            get => GetValue(BindableSelectedItemsProperty);
            set => SetValue(BindableSelectedItemsProperty, value);
        }
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
            if (BindableSelectedItems == null || !this.IsInitialized) return; //Handle pre initilized calls
            if (e.AddedItems.Count > 0)
                if (!string.IsNullOrWhiteSpace(SelectedValuePath))
                {
                    foreach (var item in e.AddedItems)
                        if (!BindableSelectedItems.Contains((dynamic)item.GetType().GetProperty(SelectedValuePath).GetValue(item, null)))
                            BindableSelectedItems.Add((dynamic)item.GetType().GetProperty(SelectedValuePath).GetValue(item, null));
                }
                else
                {
                    foreach (var item in e.AddedItems)
                        if (!BindableSelectedItems.Contains((dynamic)item))
                            BindableSelectedItems.Add((dynamic)item);
                }
            if (e.RemovedItems.Count > 0)
                if (!string.IsNullOrWhiteSpace(SelectedValuePath))
                {
                    foreach (var item in e.RemovedItems)
                        if (BindableSelectedItems.Contains((dynamic)item.GetType().GetProperty(SelectedValuePath).GetValue(item, null)))
                            BindableSelectedItems.Remove((dynamic)item.GetType().GetProperty(SelectedValuePath).GetValue(item, null));
                }
                else
                {
                    foreach (var item in e.RemovedItems)
                        if (BindableSelectedItems.Contains((dynamic)item))
                            BindableSelectedItems.Remove((dynamic)item);
                }
        }
        private static void OnBindableSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MultipleSelectionListBox listBox)
            {
                List<dynamic> newSelection = new List<dynamic>();
                if (!string.IsNullOrWhiteSpace(listBox.SelectedValuePath))
                    foreach (var item in listBox.BindableSelectedItems)
                    {
                        foreach (var lbItem in listBox.Items)
                        {
                            var lbItemValue = lbItem.GetType().GetProperty(listBox.SelectedValuePath).GetValue(lbItem, null);
                            if ((dynamic)lbItemValue == (dynamic)item)
                                newSelection.Add(lbItem);
                        }
                    }
                else
                    newSelection = listBox.BindableSelectedItems as List<dynamic>;
                listBox.SetSelectedItems(newSelection);
            }
        }
    }

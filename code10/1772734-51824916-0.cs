    public class MultipleSelectionListBox : ListBox
    {
        public static readonly DependencyProperty BindableSelectedItemsProperty =
            DependencyProperty.Register("BindableSelectedItems",
                typeof(IEnumerable<dynamic>), typeof(MultipleSelectionListBox),
                new FrameworkPropertyMetadata(default(IEnumerable<dynamic>),
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnBindableSelectedItemsChanged));
        public IEnumerable<dynamic> BindableSelectedItems
        {
            get => (IEnumerable<dynamic>)GetValue(BindableSelectedItemsProperty);
            set => SetValue(BindableSelectedItemsProperty, value);
        }
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
            BindableSelectedItems = SelectedItems.Cast<dynamic>();
        }
        private static void OnBindableSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MultipleSelectionListBox listBox)
            {
                List<dynamic> newSelection = new List<dynamic>();
                if (!string.IsNullOrWhiteSpace(listBox.SelectedValuePath))
                    foreach (var item in listBox.BindableSelectedItems)
                    {
                        var collectionValue = item.GetType().GetProperty(listBox.SelectedValuePath).GetValue(item, null);
                        foreach (var lbItem in listBox.Items)
                        {
                            if (lbItem.GetType().GetProperty(listBox.SelectedValuePath).GetValue(lbItem, null) == collectionValue)
                                newSelection.Add(lbItem);
                        }
                    }
                else
                    newSelection = listBox.BindableSelectedItems as List<dynamic>;
                listBox.SetSelectedItems(listBox.BindableSelectedItems);
            }
        }
    }

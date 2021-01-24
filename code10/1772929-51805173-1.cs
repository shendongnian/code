    public class GetRowIndexConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = (ListViewItem)value;
    
            var listView = (ListView)ItemsControl.ItemsControlFromItemContainer(item);
            int index = listView.ItemContainerGenerator.IndexFromContainer(item);
    
            return index;
        }
    
        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

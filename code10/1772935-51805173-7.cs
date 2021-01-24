    public class MyMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var listViewItem = (ListViewItem)values[0];
            ListView listView = (ListView)ItemsControl.ItemsControlFromItemContainer(listViewItem);
            int index = listView.ItemContainerGenerator.IndexFromContainer(listViewItem);
            if (values[1] == DependencyProperty.UnsetValue)
            {
                /*i.e. Object1.Object2.AddStatus - if Object2 is null then binding will return UnsetValue */
                return false;
            }
            Visibility addStatus = (Visibility)values[1];
            return index == 0 && addStatus == Visibility.Visible;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

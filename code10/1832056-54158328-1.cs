    public class ListIndexToValueConverter : IMultiValueConverter
    {
        private IList _list;
        private int _index;
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
                return Binding.DoNothing;
            if (values[0] is IList && values[1] is int)
            {
                _list = (IList)values[0];
                _index = (int)values[1];
                return _list[_index];
            }
            return Binding.DoNothing;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            _list[_index] = value;
            return new object[] { Binding.DoNothing, Binding.DoNothing };
        }
    }

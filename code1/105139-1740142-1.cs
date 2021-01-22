      private class CellAccessConverter : IValueConverter
      {
        public static readonly Instance = new CellAccessConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          return ((MyTableRow)value).Cells[(int)parameter];
        }
        object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
          throw new NotImplementedException();
        }
      }

    public class GameListEmptyOptionValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = value as ObservableCollection<Game>;
            v?.Insert(0, new Game() { Name = "NONE" });
            return v;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class ViewModel : INotifyPropertyChanged
    {
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private Color[] _backgroundColours = new Color[] { Colors.AliceBlue, Colors.Aqua, Colors.Azure };
        public Color[] BackgroundColours
        {
            get => _backgroundColours;
            set
            {
                _backgroundColours = value;
                OnPropertyChanged();
            }
        }
        private int _backgroundIndex = 1;
        public int ChosenIndex
        {
            get => _backgroundIndex;
            set
            {
                _backgroundIndex = value;
                OnPropertyChanged();
            }
        }
    }
...
    public class BackgroundConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var backgroundColours = values[0] as Color[];
            var chosenIndex = (int)values[1];
            return new SolidColorBrush(backgroundColours[chosenIndex]);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

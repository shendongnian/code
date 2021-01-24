    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private bool _resault;
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public bool Resault
        {
            get => _resault;
            set
            {
                _resault = value;
                onPropertyChanged();
            }
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Resault = !Resault;
        }
    }
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool)value ? new BitmapImage(new Uri("ms-appx:///Assets/bc1.jpg")) : new BitmapImage(new Uri("ms-appx:///Assets/bc2.jpg"));
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

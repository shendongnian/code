    class VisibilityScreenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ScreenToShow.MenuState)
            {
                var state = (ScreenToShow.MenuState)value;
                if ((string)parameter == "menuPage")
                {
                    switch (state)
                    {
                        case ScreenToShow.MenuState.MenuPage:
                            return Visibility.Visible;
                        default:
                            return Visibility.Hidden;
                    }
                }
                else if ((string)parameter == "menuChoice1")
                {
                    switch (state)
                    {
                        case ScreenToShow.MenuState.MenuChoice1:
                            return Visibility.Visible;
                        default:
                            return Visibility.Hidden;
                    }
                }
                else if ((string)parameter == "menuChoice2")
                {
                    switch (state)
                    {
                        case ScreenToShow.MenuState.MenuChoice2:
                            return Visibility.Visible;
                        default:
                            return Visibility.Hidden;
                    }
                }
                else // Menu choice 3
                {
                    switch (state)
                    {
                        case ScreenToShow.MenuState.MenuChoice3:
                            return Visibility.Visible;
                        default:
                            return Visibility.Hidden;
                    }
                }
            }
            else
            {
                return Visibility.Visible;
            }
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
    public class ScreenToShow : INotifyPropertyChanged
    {
        public enum MenuState { MenuPage, MenuChoice1, MenuChoice2, MenuChoice3 };
    
        MenuState state;
    
        public MenuState _State
        {
            get { return state; }
            set
            {
                state = value;
                this.NotifyPropertyChanged("_State");
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void MenuChoice1_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as ScreenToShow)._State = ScreenToShow.MenuState.MenuChoice1;
        }
    
        private void MenuChoice2_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as ScreenToShow)._State = ScreenToShow.MenuState.MenuChoice2;
        }
    
        private void MenuChoice3_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as ScreenToShow)._State = ScreenToShow.MenuState.MenuChoice3;
        }
    }

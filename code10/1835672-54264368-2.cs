    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeViewModel();
        }
        public ViewModel ViewModel => DataContext as ViewModel;
        private void InitializeViewModel()
        {
            DataContext = new ViewModel();
            ViewModel.PropertyChanged += (sender, args) =>
            {
                // Update the password box only when it's not visible;
                // otherwise, the cursor goes to the beginning on each keystroke
                if (!PasswordBox.IsVisible)
                {
                    if (args.PropertyName == nameof(ViewModel.Password))
                        PasswordBox.Password = ViewModel.Password;
                }
            };
        }
        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.Password = PasswordBox.Password;
        }
    }

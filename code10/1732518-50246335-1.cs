    public partial class MainWindow : Window
    {
        private readonly MainVm _mainVm;
        public MainWindow()
        {
            InitializeComponent();
            _mainVm = new MainVm();
            DataContext = _mainVm;
        }
        void SetAmountCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        void SetAmountCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            object param = e.Parameter; //CommandParameter
            TextBox textbox = e.OriginalSource as TextBox; //CommandTarget
            if (textbox != null)
            {
                textbox.Text = param.ToString();
            }
        }
    }

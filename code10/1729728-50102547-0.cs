    public partial class View2 : Page
    {
        public View2()
        {
            InitializeComponent();
            Loaded += View2_Loaded;
        }
        private void View2_Loaded(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as ViewModel2;
            if (viewModel != null)
                viewModel.YourCommand.Execute(null);
            Loaded -= View2_Loaded;
        }
    }

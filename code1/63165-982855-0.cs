    public partial class Page : UserControl
    {
        private PageViewModel _viewModel = new PageViewModel();
        public PageViewModel ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value; }
        } 
        public Page()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Page_Loaded);
        }
        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = ViewModel;
        }
    }

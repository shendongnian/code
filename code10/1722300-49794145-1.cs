    public partial class Page1 : UserControl
    {
        public Page1()
        {
            InitializeComponent();
            powerPointBrowser1.Navigate("http://www.bbc.co.uk");
        }
    }
    public partial class MainWindow : Window
    {
        private Page1Model _pageModel;
        public MainWindow()
        {
            InitializeComponent();
            _pageModel = new Page1Model();
            DataContext = _pageModel;
            ctlPage1.powerPointBrowser1.LoadCompleted += _pageModel.BrowserLoadCompleted;
        }

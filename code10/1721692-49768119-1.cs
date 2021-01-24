    public partial class Page1 
    {
        public Page1()
        {
            InitializeComponent();
        }
        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            var page2 = new Page2(this);
            NavigationService.Navigate(page2);
        }
    }

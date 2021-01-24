    public partial class Page2
    {
        private Page1 _page1;
        public Page2(Page1 page1)
        {
            InitializeComponent();
            _page1 = page1;
        }
        private void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_page1);
        }
    }

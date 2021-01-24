    public partial class HomePage : TabbedPage
    {
        public string MenuName { get; set; }
        public HomePage()
        {
            InitializeComponent();         
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (MenuName == "Movies")
            {
                this.CurrentPage = Children[1];
            }
        }
    }

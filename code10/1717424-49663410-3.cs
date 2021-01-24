    public partial class TabbedPage1 : TabbedPage
    {
        NavigationPage homePage;
        NavigationPage phrasesPage;
        public TabbedPage1 ()
        {
            InitializeComponent();
            var homePage = new NavigationPage(new Page1())
            {
                Title = "Home",
                Icon = "1.png"
            };
            var phrasesPage = new NavigationPage (new Page2())
            {
                Title = "Play",
                Icon = "1.png"
            };
            Children.Add(homePage);
            Children.Add(phrasesPage);
            this.CurrentPageChanged += (object sender, EventArgs e) => {
                var i = this.Children.IndexOf(this.CurrentPage);
                if (i == 0)
                {
                    homePage.Title = "HomeChanged";
                    homePage.Icon = "2.png";
                }
                else {
                    phrasesPage.Title = "PlayChanged";
                    phrasesPage.Icon = "2.png";
                }
            };
        }
    }

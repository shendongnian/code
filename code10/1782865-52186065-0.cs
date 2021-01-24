    public partial class TabPage : TabbedPage
    {
        Page TabOne;
        Page TabTwo;
        Page TabThree;
        public TabPage()
        {
            TabOne = new NavigationPage(new TabOnePage());
            TabTwo = new NavigationPage(new TabTwoPage());
            TabThree = new NavigationPage(new TabThreePage());
            Children.Add(homePage);
            Children.Add(resourcesPage);
            Children.Add(helpPage);
        }
    }

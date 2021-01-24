     private void OnMenuSelected(object sender, SelectedItemChangedEventArgs e)
            {
    
                //Type page = (MasterPageItem)e.SelectedItem.TargetType; 
                //page is HomePage           
                var page = (Page) Activator.CreateInstance(page);
                Detail = new NavigationPage(page);
                if (page is MyTabbedPage tabbedPage)
                    tabbedPage.Initialize(params);
            }
    public partial class HomePage : MyTabbedPage
        {
            public string MenuName { get; set; }
            public HomePage()
            {
                InitializeComponent();
                //if (MenuName == "Movies")
                //this.CurrentPage = Children[1];
            }
    
            public override void Initialize(object parameters)
            {
                //Stuff
            }
        }

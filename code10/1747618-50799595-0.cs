    public partial class Page1 : Page
    {
        public Page1()
	{
 	    InitializeComponent();
	    MyListView.SelectionChanged += MainViewModel.MyListView_SelectionChanged;
	}
        ...
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnStartup(e);
            MyListView.SelectionChanged -= MainViewModel.MyListView_SelectionChanged;
        }
    } 

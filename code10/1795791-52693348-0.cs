    public sealed partial class BookInfo_View : Page
    {
        //don't worry about DataAccess. 
        private Book book = new Book();
        private List<string> Tags = DataAccess.GetTags();
        private string[] selectedTags;
    
        public BookInfo_View()
        {
            this.InitializeComponent();
        }
    
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            book = (Book)e.Parameter;
    
            //dont worry about how this works. This line of code gives me the tags
            selectedTags = book.Tags.Split(';', System.StringSplitOptions.RemoveEmptyEntries);
    
            //here i want to select the selected tags
            this.Loaded += OnPageLoaded;
        }
    
        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
           foreach (string selectedTag in selectedTags)
           {
             TagsListView.SelectedItems.Add(selectedTag);
           }
        }
    }

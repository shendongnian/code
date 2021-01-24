    public ObservableCollection<Category> Categories { get; set; }
    public MainPage()
    {
        this.InitializeComponent();
        Categories = new ObservableCollection<Category>();
        Categories.Add(new Category { Name = "Category 1", Glyph = Symbol.Home, Tooltip = "This is category 1", IsEnabled = false });
        Categories.Add(new Category { Name = "Category 2", Glyph = Symbol.Keyboard, Tooltip = "This is category 2", IsEnabled = true });
        Categories.Add(new Category { Name = "Category 3", Glyph = Symbol.Library, Tooltip = "This is category 3", IsEnabled = true });
        Categories.Add(new Category { Name = "Category 4", Glyph = Symbol.Mail, Tooltip = "This is category 4", IsEnabled = true });
    
    }
    public IEnumerable<NavigationViewItemBase> NavItems
    {
        get
        {
            return Categories.Select(
                   b => (new NavigationViewItem
                   {
                       Content = b.Name,
                       Icon = new SymbolIcon(b.Glyph),
                       IsEnabled = b.IsEnabled,
                   })
            );
        }
    }
     

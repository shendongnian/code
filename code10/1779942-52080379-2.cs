    public MainWindow()
    {
        InitializeComponent();
        // here, list is the collection of items with mentioned properties.
        lv.ItemsSource = list;
        var view = (CollectionView)CollectionViewSource.GetDefaultView(lv.ItemsSource);
        if (view.GroupDescriptions != null)
        {
            view.GroupDescriptions.Clear();
            view.GroupDescriptions.Add(new PropertyGroupDescription("ItemGroup"));
        }
        Loaded += (s, e) =>
        {
            foreach (Expander gi in FindVisualChildren<Expander>(lv))
            {
                gi.IsExpanded = true;
            }
        };
    }

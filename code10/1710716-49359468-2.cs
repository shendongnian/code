    public MainPage()
    {
        this.InitializeComponent();
    
        this.Loaded += MainPage_Loaded;
        OperateItems = new List<Bilder>();
    }
    
    List<Bilder> OperateItems;
    
    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        //these two lines code could be deleted if you don't set the default selected item
        Carousel.SelectedIndex = 0;
        ((Bilder)Carousel.SelectedItem).BorderColor = new SolidColorBrush(Colors.Gray);
    }
    
    private void Carousel_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        OperateItems.Clear();
        foreach (Bilder item in e.AddedItems)
        {
            OperateItems.Add(item);
        }
        foreach (Bilder item in e.RemovedItems)
        {
            OperateItems.Add(item);
        }
    
        foreach (Bilder item in Carousel.Items)
        {
            if (OperateItems.Contains(item))
            {
                item.BorderColor = new SolidColorBrush(Colors.Gray);
            }
            else
            {
                item.BorderColor = new SolidColorBrush(Colors.Transparent);
            }
        }
    }

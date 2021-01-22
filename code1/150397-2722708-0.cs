    public New()
    {
        
        // This call is required by the designer.
        InitializeComponent();
        
        _Items.Add(new Company { Name = "Company1", NumberOfHotels = 5 });
        _Items.Add(new Company { Name = "Company2", NumberOfHotels = 15 });
        _Items.Add(new Company { Name = "Company3", NumberOfHotels = 30 });
        
            
        tvItems.ItemsSource = _Items;
    }
    
    private void BTNAddProvince_Click(System.Object sender, System.Windows.RoutedEventArgs e)
    {
        
        Button button = sender as Button;
        if (button == null) return;     
            
        TreeViewItem treeViewItem = GetVisualParent<TreeViewItem>(button);
    }
    
    public static T GetVisualParent<T>(Visual referencedVisual) where T : Visual
    {
        
        Visual parent = referencedVisual;
        
        while (parent != null && !object.ReferenceEquals(parent.GetType, typeof(T))) {
            parent = VisualTreeHelper.GetParent(parent) as Visual;
        }
        
        var parent1 = VisualTreeHelper.GetParent(referencedVisual);
        
            
        return parent as T;
    }

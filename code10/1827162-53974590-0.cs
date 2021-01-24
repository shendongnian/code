    public UserMenuInterface()
    {
      InitializeComponent();
      this.MenuImageContextMenu.Loaded += FindControl;
    }
    private void FindControl(object sender, RoutedEventArgs e)
    {
       var BeverageMenuItem = this.MenuImageContextMenu.Template.FindName("BeverageMenuItem", MenuImage) as CustomMenuItem;
    }

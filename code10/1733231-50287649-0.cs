    public MainPage()
    {
        this.InitializeComponent();
        for (int i = 0; i < 5; i++)
        {
            MenuFlyoutSubItem myItem = new MenuFlyoutSubItem();
            myItem.Text = "Item" + i;
            myItem.AddHandler(PointerEnteredEvent, new PointerEventHandler(PointEnterHandler), true);
            MyMenu.Items.Add(myItem);
            for (int j = 0; j < 4; j++)
            {
                MenuFlyoutItem mySubItem = new MenuFlyoutItem();
                mySubItem.Text = "SubItem" + j;
                mySubItem.PointerEntered += mySubItem_PointerEntered;
                myItem.Items.Add(mySubItem);
            }
        }
    }
    
    private void PointEnterHandler(object sender, PointerRoutedEventArgs e)
    {
        MenuFlyoutSubItem test = sender as MenuFlyoutSubItem;
        var menuFlyoutSubItemText = test.Text;
    }
    
    private void mySubItem_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
    {   //This works. It is triggered when the mouse pointer enters the menu flyout item.
        MenuFlyoutItem test = sender as MenuFlyoutItem;
        var menuFlyoutItemText = test.Text;
    }

    public  Page ()
    		{
                NavigationPage.SetHasNavigationBar(this, false); //remove nav bar
                InitializeComponent ();
                LoadOrders();//populates Observable collection
               FlowListViewH.FlowItemsSource = OrdersForKitchenPage;//sets source to Observable collection
                
            }

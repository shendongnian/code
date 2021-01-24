    void OnChange(NSNotification notification)
    {
        string s = notification.Object as NSString;
        if(s is "Add")
        {
            tableItems.Add(new TableItem("Vegetables") { SubHeading = "65 items", ImageName = "Vegetables.jpg" });
        }
        else
        {
            int index = (notification.Object as NSIndexPath).Row;
            tableItems.RemoveAt(index);
        }
        table.ReloadData();
    }
    public override void ViewDidLoad ()
    {
	    base.ViewDidLoad ();
        NSNotificationCenter.DefaultCenter.AddObserver(new NSString("Cell"), OnChange,this);
        //xxx
    }

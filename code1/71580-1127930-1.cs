    public override Style SelectStyle(object item, DependencyObject container)
    {
        ItemsControl ic = ItemsControl.ItemsControlFromItemContainer(container);
        MyItem selectedItem = (MyItem)item;
        Style s = new Style();
        var listMenuItems = new List<MenuItem>();
        var mi = new MenuItem();
        mi.Header= "Get Metadata";
        mi.Name= "cmMetadata";
        mi.Command = CustomCommands.DisplayMetadata;
        mi.CommandParameter = selectedItem;
        listMenuItems.Add(mi);
        ContextMenu cm = new ContextMenu();
        cm.ItemsSource = listMenuItems;
        // Global styles
        s.Setters.Add(new Setter(Control.ContextMenuProperty, cm));
            
        // other style selection code
        return s;
    }

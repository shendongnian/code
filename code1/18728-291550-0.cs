    //Add to main menu
    MenuItem newMenuItem1 = new MenuItem();
    newMenuItem1.Header = "Test 123";
    this.MainMenu.Items.Add(newMenuItem1);
    
    //Add to a sub item
    MenuItem newMenuItem2 = new MenuItem();
    MenuItem newExistMenuItem = (MenuItem)this.MainMenu.Items[0];
    newMenuItem2.Header = "Test 456";
    newExistMenuItem.Items.Add(newMenuItem2);

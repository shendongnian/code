    //create a new list of SubItem
    List<SubItem> SubItems = new List<SubItem>();
    
    //add some data
    SubItems.Add(new SubItem() { displayName = "Test 1", value = "1" });
    SubItems.Add(new SubItem() { displayName = "Test 2", value = "2" });
    SubItems.Add(new SubItem() { displayName = "Test 3", value = "3" });
    
    //create the dropdownlist and bind the data
    DropDownList x = new DropDownList();
    x.DataSource = SubItems;
    x.DataValueField = "value";
    x.DataTextField = "displayName";
    x.DataBind();
    
    //put the dropdownlist on the page
    PlaceHolder1.Controls.Add(x);

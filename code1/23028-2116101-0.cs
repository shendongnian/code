    //Item class
    Class Item
    {
       public string Name { get; set; }
    }
    
    List < Item > myList = new List< Item >()
    
    //Add item to list
    Item item = new Item();
    item.Name = "Name";
    
    myList.Add(Item);
    
    //Find the item with the name prop
    
    Item item2 = myList.Find(x => x.Name == "Name");
    
    if(item2 != null)
       item.Name = "Changed";

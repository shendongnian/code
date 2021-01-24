    public static Item xItem = new Item();
    public static List<Item> list = new List<Item>();
    xItem.Code = "A";
    xItem.Description = "A";
    xItem.Price= "1";
    xItem.Qty = "1";
    list.Add(xItem);
    //list now has 'A' with value of 1 in it..
   
    xItem.Code = "B"
    //without any further change, list will now have the same 
    //item, so its Code will now be "B":
    //this will be TRUE:
    var listIsNowB = (list[0].Code == "B");

    //why are these static? That seems like a bad idea, but we lack enough context to know for sure
    public static Item xItem;
    public static List<Item> item = new List<Item>();
    
    xItem = new Item();
    xItem.Code = txtCode.Text;
    xItem.Description = txtDescription.text;
    xItem.Price= txtPrice.text;
    xItem.Qty = txtQty.text;

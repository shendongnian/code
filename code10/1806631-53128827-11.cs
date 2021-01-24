    public class ItemDetailTable
    {
        public int ItemSeq { get; set; }
        public string ItemName { get; set; }
        public double? Amount { get; set; }
    
        public string Id { get; set; }   //Foreign key of ItemTable
    }
    public ItemTable GetItems(string id)
    {
        //Get "ItemTable" record from database
        var item = _context.ItemTable.Where(x => x.Id == id).SingleOrDefault();
        //Retrieve its "Items" and sort by ascending order
        var itemDetails = item.Items.Where(x => x.Id == id).Where(p => p.Amount != null).OrderBy(x => x.Amount).ToList();
        //Preare a new "ItemTable" object to return
        ItemTable itemTable = new ItemTable
        {
            Code = item.Code,
            Id = item.Id,
            Items = itemDetails
        };
        //Return new "itemTable" with sorted list of "ItemDetailTable"
        return itemTable;
    }

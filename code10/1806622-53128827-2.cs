    public List<ItemDetailTable> GetItems(string id)
    {
        //Get "ItemTable" record with its ID
        var item = _context.ItemTable.Where(x => x.Id == id).SingleOrDefault();
        //Sort "ItemDetailTable" records with "Amount"
        var itemDetails = item.Items.Where(p => p.Amount != null).OrderBy(x => x.Amount).ToList();
        //Return sorted list of "ItemDetailTable"
        return itemDetails;
    }

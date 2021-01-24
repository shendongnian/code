    public List<ItemModel> GetItems(string id)
    {
        var items = _context.SampleTable.Where(t => t.Id == id).SelectMany(x => x.Items).Where(p => p.Amount != null).OrderBy(x => x.Amount).ToList();
        return items.ToList();
    }

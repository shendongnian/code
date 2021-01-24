    public void Traverse(List<Item> list)
    {
        var parentIds = list.Where(e => e.ParentId > 0).Select(e => e.ParentId).ToList();
        var bargs = list.Where(e => !parentIds.Contains(e.Id)).ToList();
        foreach (var item in bargs)
        {
            Traverse(list, item);
        }
    }
    private void Traverse(List<Item> items, Item item)
    {
        var list = new List<Item> { item };
        int id = item.ParentId;
        while (true)
        {
            var found = items.Where(e => e.Id == id).FirstOrDefault();
            list.Insert(0, found);
            if(found.ParentId == 0) { break; }
            id = found.ParentId;
        }
        var str = string.Empty;
        foreach (var node in list)
        {
            str += node.Name;
            if(node != item) { str += ":"; }
        }
        Console.WriteLine(str);
    }

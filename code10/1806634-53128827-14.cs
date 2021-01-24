    public ItemTable GetItems(string id)
    {
        var result = (from i in _context.ItemTable
                      where i.Id == id
                      let sorting = i.Items.Where(x => x.Id == id).Where(x => x.Amount != null).OrderBy(x => x.Amount).ToList()
                      select new ItemTable
                      {
                          Id = i.Id,
                          Code = i.Code,
                          Items = sorting
                      }).FirstOrDefault();   //Or => SingleOrDefault
    
        return result;
    }

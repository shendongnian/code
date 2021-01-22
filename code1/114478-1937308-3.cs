    public List<ReturnValue> thisIsAtest()
    {
       DbContext.Table.Where(u => u.Table.UserId == userId && u.OutOFF != 0)
         .GroupBy(u => new { u.Table.Prefix })
         .Select(group => new ReturnValue 
                              { prefix = group.Key, 
                                Marks = group
                                  .Sum(item => (item.Mark * item.Weight) / item.OutOFF) })
         .ToList();
    }

    foreach (var s in source)
    {
        var item = target.Where(t => t.Id == s.Id).FirstOrDefault();
        if (item != null)
        {
            item.Id = s.Id;
            item.Desc = s.Desc;
        }
    }

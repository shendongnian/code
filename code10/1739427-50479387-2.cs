    var list = db.Products.ToList().AsQueryable();
    if (propertyName == "Id")
    {
        list = list.Where(x=>x.Id == (int)value);
    }
    else if (propertyName == "Name")
    {
        list = list.Where(x=>x.Name == (string)value);
    }
    var result = list.ToList();

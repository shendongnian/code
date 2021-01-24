    var list = db.Products.ToList();
    var result = list.ToList();
    if (propertyName == "Id")
    {
        result = result.Where(x=>x.Id == (int)value).ToList();
    }
    else if (propertyName == "Name")
    {
        result = result.Where(x=>x.Name == (string)value).ToList();
    }

    var query = list.GroupBy(
        item => new { item.Category, item.Code },
        (key, group) => new Foo { Category = key.Category, 
                                  Code = key.Code,
                                  Quantity = group.Sum(x => x.Quantity) });

    IQueryable<Item> vItems = vSearchItems.GetItems(vZoekString);
    var viewModels = vItems.OrderBy(x => x.ITEM)
        .Select(x => new ItemViewModel
        {
           ItemId = x.ItemId,
           // .. Continue populating view model. If model contains a hierarchy of data, map those to related view models as well.
        }).ToPagedList(page, pageSize);
    
    return View(viewModels);

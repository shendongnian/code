    var list = xmlDoc.Root.Elements("ItemID")
                                       .Select(element => element.Value)
                                       .ToList();
    while(list.Any())
    {
        var subList = list.Take(5000);
        var idsList = FormItemIdList(subList);
        ctx.zsp_deleteEndedItems(idsList);
        ctx.zsp_deleteEndedItemsTransactions(idsList);
        list.RemoveRange(subList);
    }

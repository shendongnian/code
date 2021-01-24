    var changeItems = changes.OfType<ChangeItem>();
    var changeItemsResult = ctx.LoadQuery(changeItems.Include(c =>c.ChangeType, c => c.FileSystemObjectType));
    ctx.ExecuteQuery();
    foreach (var changeItem in changeItemsResult)
    {
         Console.WriteLine("{0}: {1}",changeItem.ChangeType,changeItem.FileSystemObjectType);
    }
 

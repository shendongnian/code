    var changeQuery = new ChangeQuery(false,true);
    changeQuery.Item = true; //only load change item changes
    var changes = ctx.Web.GetChanges(changeQuery);
    ctx.Load(changes, cc => cc.Include(c => c.ChangeType, c => ((ChangeItem)c).FileSystemObjectType));
    ctx.ExecuteQuery();
    foreach(var change in changes)
    {
         ChangeItem changeItem = change as ChangeItem;
         Console.WriteLine("{0}: {1}",changeItem.ChangeType,changeItem.FileSystemObjectType);
    }

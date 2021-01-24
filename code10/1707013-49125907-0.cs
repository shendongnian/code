    var result = dbContext.Repository<SomeTable>()
        ...
        .Where(someTableElement => someTableElement.Id == 1)
        .Select(tableItem => new
        {
            TableId = tableItem.TableId,
            TableName = tableIem.TableName,
        })
        .AsEnumerable()
        // from here, all elements (expected to be only one) are in local memory
        // so you can call:
        .Select(localItem => new
        {
            TableId = localItem.TableId,
            OriginalTableName = localItem.TableName.Replace("$", "_")
        })
        .SingleOrDefault(); 

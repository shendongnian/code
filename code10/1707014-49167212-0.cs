    ...
    .AsExpandable()
    .Select(item => new
     {
       TableId = item.TableId,
       OriginalTableName = SubQueryReplace(item.TableName).Expand()
     })
    ...

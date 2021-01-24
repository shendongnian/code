    var result = myInputSequence.Select(sourceItem => new
    {
       
        SplitOrderNumbers = (sourceItem.Order.Split(';')
            .Select(splitItem => Int32.Parse(splitItem))
            .Take(3)
            .ToList(),
        OriginalSourceItem = sourceItem,
    })
    .OrderBy(item => item.SplitOrderNumbers[0])
    .ThenBy(item => item.SplitOrderNumbers[1])
    .ThenBy(item => item.SplitOrderNumbers[2])
    .Select(item => item.OriginalSourceItem);

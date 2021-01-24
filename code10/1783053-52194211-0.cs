    var sortedItems =
        // First select a new item for all non-null StartTimes
        items.Where(i => i.StartTime.HasValue) 
            .Select(i => new ExceptionFolderEntries {Data = i.Data, StartTime = i.StartTime})
            // Then concat with a new item for all non-null EndTimes
            .Concat(items
                .Where(i => i.EndTime.HasValue) 
                .Select(i => new ExceptionFolderEntries {Data = i.Data, EndTime = i.EndTime}))
            // And finally, order by the non-null field
            .OrderBy(i => i.StartTime ?? i.EndTime)
            .ToList();
    // Now we can write out the data and the non-null field for each item
    sortedItems.ForEach(i => Console.WriteLine($"{i.Data} {i.StartTime ?? i.EndTime}"));

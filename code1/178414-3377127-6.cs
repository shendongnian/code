        List<int> columns = new List<int>(new[] { 0 });
        var result = columns.Aggregate(
            new[] { rows.AsEnumerable() }.AsEnumerable(),   // IEnumerable<object[]> = group, IEnumerable<group> = result
            (groups, nCol) => groups
                .Select(g => g.GroupBy(row => row[nCol]))   // regroup each collection of rows
                .SelectMany(g => g)                         // flatten all groups into one group collection
                .Select(g => g.Select(row => row)));        // groups to IEnumerable

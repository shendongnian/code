        List<int> columns = new List<int>(new[] { 0, 1, 2 });
        var result = new List<IEnumerable<object[]>>( new[] { rows } );
        result = columns.Aggregate(result, (r, nCol) => r
                .Select(g => g.GroupBy(k => k[nCol]))   // regroup each collection of rows
                .SelectMany(s => s)                     // flatten all groups into one group collection
                .Select(g => g.Select(row => row))      // groups to IEnumerable
                .ToList());

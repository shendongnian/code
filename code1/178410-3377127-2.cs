        var result = new List<IEnumerable<object[]>>( new[] { rows } );
        foreach (var nCol in columns)
        {
            result = result
                .Select(g => g.GroupBy(k => k[nCol]))   // regroup each collection of rows
                .SelectMany(s => s)                     // flatten all groups into one group collection
                .Select(g => g.Select(row => row))      // groups to IEnumerable
                .ToList();                              
        }

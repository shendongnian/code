    var fallBackValue =  values
        .Where(v =>  v.Columns.All(c => string.IsNullOrEmpty(c.Code))
        .Select(v => v.Value)
        .FirstOrDefault();
    var x = values
        .Where(v => v.Columns.Any(c => c.Code == code && c.Value == value))
        .Select(v => v.Value)
        .DefaultIfEmpty(fallBackValue)
        .First(); // FirstOrDefault not nessesary anymore;

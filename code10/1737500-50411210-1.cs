    var x = values
        .Where(v => v.Columns.Any(c => c.Code == code && c.Value == value))
        .Select(v => v.Value)
        .Concat(values // second alternative if 1st returns empty cursor
           .Where(v => v.Columns.All(c => string.IsNullOrEmpty(c.Code))
           .Select(v => v.Value))
        .FirstOrDefault();

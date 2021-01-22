    var dic = db
            .Table
            .Select(p => new { p.Key, p.Value })
            .AsEnumerable()
            .ToDictionary(k=> k.Key, v => v.Value);

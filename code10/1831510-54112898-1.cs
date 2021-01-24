    var branchOverrides = overridesSqlContext.Overrides
            .Where(q => q.Type == "Branch Override")
            .Select(s => new
            {
                s.Value,
                s.OverrideValue
            })
            .AsEnumerable()
            .ToDictionary(k => k.Value, v => v.OverrideValue);

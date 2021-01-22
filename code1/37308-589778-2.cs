    var lookup = types.ToLookup(type => type.Id);
    foreach (var s in vars)
    {
        var types = lookup[s];
        if (types != null)
        {
            var type = types.First(); // Guaranteed to be at least one entry
            Add(new NameValuePair(type.Id, type.Text));
        }
    }

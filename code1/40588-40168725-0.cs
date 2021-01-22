    var directoryEntry = adUser.GetUnderlyingObject() as DirectoryEntry;
    directoryEntry.RefreshCache();
    var propNames = directoryEntry.Properties.PropertyNames.Cast<string>();
    var props = propNames
        .Select(x => new { Key = x, Value = directoryEntry.Properties[x].Value.ToString() })
        .ToList();

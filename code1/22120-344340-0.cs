    var matchingProperties = pi.Where(exactNames.Contains(pi.Name) ||
                              partialNames.Any(name => pi.Name.Contains(name));
    foreach (PropertyInfo property in matchingProperties)
    {
        // Stuff
    }

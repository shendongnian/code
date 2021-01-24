    var result = flagColors
        .GroupBy(flagColor => flagColor.Country.CountryName)
        .Select(group => new
        {
            CountryName = group.Key,                         // get common CountryName
            FlagColors = group                               // get the color of all elements
                .Select(groupElement => groupElement.Color)  // in the group
                .ToList(),
        })

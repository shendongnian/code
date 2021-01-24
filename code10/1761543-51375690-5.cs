    string[] versionStrings = new [] {"3.5.25569", "2.5.25557", "2.5.25580", "2.5.25569", "2.4.25569"};
    // parsing
    IEnumerable<VersionNumber> versions = versionStrings.Select(s => VersionNumber.Parse(s));
    // sorting
    IOrderedEnumerable<VersionNumber> sorted = versions.OrderBy(v => v);
    // sorted: 2.4.25569, 2.5.25557, 2.5.25569, 2.5.25580, 3.5.25569

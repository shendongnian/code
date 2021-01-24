    _CompanyOwnedDomains = new HashSet<string>(
        // ReadLines allows you to process before reading the entire file
        File.ReadLines(CompanyOwnedDomainsFileName)
            .Where(line => !String.IsNullOrEmpty(line))
            .Where(line => !line.StartsWith("#"))
            .SelectMany(line => line.ToLower().Split(';')));

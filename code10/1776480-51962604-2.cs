    var result = lines
        // extract the values to compare
        .Select(line => new
        {
            Line = line,
            ValuesToCompare = new
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                ...
            })
        })
 
        // keep only those lines that match valuesToCheck
        .Where(line => valuesToCheck.Contains(line.ValuesToCompare));

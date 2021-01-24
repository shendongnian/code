    var b = listy
        .Select(x => x.Variable)
        .Distinct()
        // outer dictionary, key is Variable
        .ToDictionary(k => k, v => 
            listy
            // find items in the list with the same Variable
            .Where(x => x.Variable == v)
            // and create a dictionary for the Value/Coef pairs.
            .ToDictionary(k2 => k2.Value, v2 => v2.Coef));

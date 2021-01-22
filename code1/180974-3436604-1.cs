    var results = list.GroupBy(e => e.Country) // group the list by country
        .OrderByDescending(                 // then sort by the summed values DESC
            g => g.Sum(e => e.Value))  
        .Take(n)                            // then take the top X values
        .Select(                            // e.g. List.TopX(3) would return...
            r => new {Country = r.Key, Sum = r.Sum(e => e.Value)}); 

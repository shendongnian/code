    var newCountryTasks = dates.Select(date => GetCountryByDateAsync(date));
    await Task.WhenAll(newCountryTasks);
    var newCountries = 
        newCountryTasks.SelectMany(task => task.Result)
                       .Where(country => existedISOCodes.Add(country.ISO))
                       .Select(country => 
                       {
                           return new Country
                           {
                               Id = country.id,
                               Name = country.name,
                               ISO = country.iso,
                               Link = country.id.ToString()
                           };
                       });
    countries.AddRange(newCountries);
    

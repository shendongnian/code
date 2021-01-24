    States = statesOfCountry.GroupJoin(cities,   // Groupjoin states with cities
       stateOfCountry => stateOfCountry.Id,      // from every state take the Id
       city => city.StateId,                     // from every city take the stateId
       (stateOfCountry, citiesOfState) => new    // again: when they match make a new object
       {
            // for performance: select only the properties yo actually plan to use
            Id = stateOfCountry.Id,
            Name = stateOfCountry.Name,
            // not needed: you know it equals Country.Id:
            // CountryId = stateOfCountry.CountryId,
            Cities = citiesOfState.Select(city => new
            {
                 // only the properties you plan to use
                 Id = city.Id,
                 Name = city.Name,
                 Location = city.Location,
                 // not needed, you already know the value:
                 // StateId = city.StateId,
            }),
       }

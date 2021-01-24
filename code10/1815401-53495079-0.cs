    var result = countries.GroupJoin(states,  // GroupJoin countries and states
       country => country.Id,                 // from the country take the primary key
       state => state.CountryId               // from the state take the foreign key
       (country, statesOfCountry) => new      // from every country with all its states
       {                                      // make one new object
           Id = country.Id,                   // cointaining only the properties you plan to use
           Name = country.Name,
           ...
           States = ...                       // see below
       }

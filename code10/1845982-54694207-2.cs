    string SelectNameToDisplayOrDefault(IEnumerable<Person> persons)
    {
        // TODO: exception if persons equals null
        // select the person with the name that occurs most
        // group them by name, and count the number of persons in each group
        // finally take the group with the largest number of persons
        var mostUsedName = persons
            .GroupBy(person => person.Name,       // KeySelector
                (name, personsWithThisName) => new // ResultSelector
                {
                    Name = name,
                    Count = personsWithThisName.Count(),
                })
             // order such that the person that occurs most comes first
             .OrderByDescending(person => person.Count)
             // keep only the name:
             .Select(person => person.Name)
             // and take the first one
             .FirstOrDefault();
         return mostUsedName;             
    }

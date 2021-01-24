    string SelectNameToDisplayOrDefault(IEnumerable<Person> persons)
    {
        var personsWithCount = persons
            .GroupBy(person => person.Name,       // KeySelector
                (name, personsWithThisName) => new // ResultSelector
                {
                    Name = name,
                    Count = personsWithThisName.Count(),
                });
        // get the person that has the highest count, enumerating only once:
        var personEnumerator = personsWithCount.GetEnumerator();
        if (personEnumerator.MoveNext())
        {
            // there is at least one Person:
            var mostOftenCountedPerson = personEnumerator.Current;
            // check if other persons have a higher count:
            while (personEnumerator.MoveNext())
            {
                // there is a next Person; does he have a higher Count?
                if (personEnumerator.Current.Count > mostOftenCountedPerson.Count)
                {
                     // yes this person is counted more often
                     mostOftenCountedPerson = personEnumerator.Current;
                }
            }
            // enumerated the sequence exactly once, and we know the Person that is counted most
            return mostOftenCountedPerson;
        }
        else
        {   
            // no person at all; TODO: decide what to do
        }
    }

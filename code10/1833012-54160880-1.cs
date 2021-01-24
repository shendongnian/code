    public IList<PersonAgeGroup> GroupPersonsByAge(List<Person> persons)
    {
            var result = persons.GroupBy(x=>x.Age)
                             .Select(x=> new PersonAgeGroup
                                       {
                                          Age= x.Key, 
                                          Persons = x.ToList()
                                       });
    
            return result.Persons.ToList();
        }

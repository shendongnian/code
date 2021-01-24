    public IList<PersonAgeGroup> GroupPersonsByAge(List<Person> persons)
    {
        return persons.GroupBy(x=>x.Age)
                             .Select(x=> new PersonAgeGroup
                                       {
                                          Age= x.Key, 
                                          Persons = x.ToList()
                                       }).ToList();
    
    }

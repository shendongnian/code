    public static IEnumerable<Person> GetPersonByMinimumAge(IEnumerable<Person> persons, int age) 
    { 
        foreach(var person in persons)
        {
            if(person.age >= age)
            {
                yield return person;
            }
        }
    }

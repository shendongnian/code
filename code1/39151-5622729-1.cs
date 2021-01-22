    var persons = new Dictionary<int, Person>();
    
    ...
    
    // For each person you want to add to the list:
    var person = new Person
    {
      ...
    };
    if (!persons.ContainsKey(person.SSN))
    {
      persons.Add(person.SSN, person);
    }
    // If you absolutely, positively got to have a List:
    List<Person> personsList = persons.Values.ToList();

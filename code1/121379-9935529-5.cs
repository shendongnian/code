    public List<Person> GetPeople(string csvContent)
    {
      List<Person> people = new List<Person>();
      CSVHelper csv = new CSVHelper(csvContent);
      foreach(string[] line in csv)
      {
        Person person = new Person();
        person.Name = line[0];
        person.TelephoneNo = line[1];
        people.Add(person);
      }
      return people;
    }

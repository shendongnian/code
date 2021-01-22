    void AddPerson(Person person)
    {
      if(person.Name != null && IsValidDate(person.BirthDate)
        DB.AddPersonToDatabase(person);
    }
    
    void AddPerson(string name, DateTime birthDate)
    {
      Person p = new Person(name, birthDate);
      this.AddPerson(p);
    }

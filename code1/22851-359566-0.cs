    public IEnumerable<Person> Get()
    {
      return l1
        .Select(p => new Person(){
          FirstName = p.FirstName,
          LastName = p.LastName
        });
    }

    // Using complex type
    class Person()
    {
        public string Name;
    }
    
    IEnumerable<Person> myEnumerable = new List<Person>();
    this.myEnumerable.OrderByDescending(person => person.Name)
    // Using value type
    IEnumerable<int> ints = new List<int>();
    ints.OrderByDescending(x => x);

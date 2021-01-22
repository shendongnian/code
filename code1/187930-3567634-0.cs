    class Person
    {
        public string Name { get; }
        public int Age { get; }
        public double Height { get; }
        public double Weight { get; }
    }
    IEnumerable<Person> people = GetPeople();
    
    var orderedByName = people.OrderBy(p => p.Name);
    var orderedByAge = people.OrderBy(p => p.Age);
    var orderedByHeight = people.OrderBy(p => p.Height);
    var orderedByWeight = people.OrderBy(p => p.Weight);

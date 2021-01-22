    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static implicit operator Person(PersonWithAge p)
        {
            return new Person() { Id = p.Id, Name = p.Name };
        }
    }
***
    List<PersonWithAge> pwa = new List<PersonWithAge>
    Person p = pwa[0];

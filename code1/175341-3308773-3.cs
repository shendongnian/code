    // Sample class
    class Person
    {
        public int Id { get; set; }
        public int RefId { get; set; }
        public string Name { get; set; }
    }
    // Then in the program...
    public static void Main(string[] args)
    {
        List<Person> people = new List<Person>
        {
            new Person(){Id=1, RefId=1 Name="ABC"},
            new Person(){Id=2, RefId=1 Name="XYZ"},
            new Person(){Id=3, RefId=2 Name="abc"},
            new Person(){Id=4, RefId=3 Name="xyz"},
            new Person(){Id=5, RefId=3 Name="test2"}
        };
        foreach (Person repeated in people.Repeating(p => p.ID))
        {
            Console.WriteLine(repeated.ID);
        }
    }

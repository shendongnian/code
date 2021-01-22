    class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
    class Pet
    {
        public string Name { get; set; }
        public Person Owner { get; set; }
    }
    public static void LeftOuterJoinExample()
    {
        Person magnus = new Person {ID = 1, FirstName = "Magnus", LastName = "Hedlund"};
        Person terry = new Person {ID = 2, FirstName = "Terry", LastName = "Adams"};
        Person charlotte = new Person {ID = 3, FirstName = "Charlotte", LastName = "Weiss"};
        Person arlene = new Person {ID = 4, FirstName = "Arlene", LastName = "Huff"};
        Pet barley = new Pet {Name = "Barley", Owner = terry};
        Pet boots = new Pet {Name = "Boots", Owner = terry};
        Pet whiskers = new Pet {Name = "Whiskers", Owner = charlotte};
        Pet bluemoon = new Pet {Name = "Blue Moon", Owner = terry};
        Pet daisy = new Pet {Name = "Daisy", Owner = magnus};
        // Create two lists.
        List<Person> people = new List<Person> {magnus, terry, charlotte, arlene};
        List<Pet> pets = new List<Pet> {barley, boots, whiskers, bluemoon, daisy};
        var query = from person in people
            where person.ID == 4
            join pet in pets on person equals pet.Owner  into personpets
            from petOrNull in personpets.DefaultIfEmpty()
            select new { Person=person, Pet = petOrNull}; 
        
        foreach (var v in query )
        {
            Console.WriteLine("{0,-15}{1}", v.Person.FirstName + ":", (v.Pet == null ? "Does not Exist" : v.Pet.Name));
        }
    }

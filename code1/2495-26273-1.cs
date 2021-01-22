    #region List Filtering
    static void Main(string[] args)
    {
        ListFiltering();
        Console.ReadLine();
    }
    private static void ListFiltering()
    {
        var PersonList = new List<Person>();
        PersonList.Add(new Person() { Age = 23, Name = "Jon", Gender = "M" }); //Non-Constructor Object Property Initialization
        PersonList.Add(new Person() { Age = 24, Name = "Jack", Gender = "M" });
        PersonList.Add(new Person() { Age = 29, Name = "Billy", Gender = "M" });
        PersonList.Add(new Person() { Age = 33, Name = "Bob", Gender = "M" });
        PersonList.Add(new Person() { Age = 45, Name = "Frank", Gender = "M" });
        PersonList.Add(new Person() { Age = 24, Name = "Anna", Gender = "F" });
        PersonList.Add(new Person() { Age = 29, Name = "Sue", Gender = "F" });
        PersonList.Add(new Person() { Age = 35, Name = "Sally", Gender = "F" });
        PersonList.Add(new Person() { Age = 36, Name = "Jane", Gender = "F" });
        PersonList.Add(new Person() { Age = 42, Name = "Jill", Gender = "F" });
        //Logic: Show me all males that are less than 30 years old.
        Console.WriteLine("");
        //Iterative Method
        Console.WriteLine("List Filter Normal Way:");
        foreach (var p in PersonList)
            if (p.Gender == "M" && p.Age < 30)
                Console.WriteLine(p.Name + " is " + p.Age);
        Console.WriteLine("");
        //Lambda Filter Method
        Console.WriteLine("List Filter Lambda Way");
        foreach (var p in PersonList.Where(p => (p.Gender == "M" && p.Age < 30))) //.Where is an extension method
            Console.WriteLine(p.Name + " is " + p.Age);
        Console.WriteLine("");
        //LINQ Query Method
        Console.WriteLine("List Filter LINQ Way:");
        foreach (var v in from p in PersonList
                          where p.Gender == "M" && p.Age < 30
                          select new { p.Name, p.Age })
            Console.WriteLine(v.Name + " is " + v.Age);
    }
    private class Person
    {
        public Person() { }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
    }
    #endregion

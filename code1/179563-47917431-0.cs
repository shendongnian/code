    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    class Child
    {
        public string Name { get; set; }
        public Person Owner { get; set; }
    }
    public class JoinTest
    {
        public static void LeftOuterJoinExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };
            Child barley = new Child { Name = "Barley", Owner = terry };
            Child boots = new Child { Name = "Boots", Owner = terry };
            Child whiskers = new Child { Name = "Whiskers", Owner = charlotte };
            Child bluemoon = new Child { Name = "Blue Moon", Owner = terry };
            Child daisy = new Child { Name = "Daisy", Owner = magnus };
            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Child> childs = new List<Child> { barley, boots, whiskers, bluemoon, daisy };
            var query = from person in people
                        join child in childs
                        on person equals child.Owner into gj
                        from subpet in gj.DefaultIfEmpty()
                        select new
                        {
                            person.FirstName,
                            ChildName = subpet!=null? subpet.Name:"No Child"
                        };
                           // PetName = subpet?.Name ?? String.Empty };
            foreach (var v in query)
            {
                Console.WriteLine($"{v.FirstName + ":",-25}{v.ChildName}");
            }
        }
        // This code produces the following output:
        //
        // Magnus:        Daisy
        // Terry:         Barley
        // Terry:         Boots
        // Terry:         Blue Moon
        // Charlotte:     Whiskers
        // Arlene:        No Child

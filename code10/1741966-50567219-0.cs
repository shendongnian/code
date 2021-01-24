    // Testclasses which will be joined
    public class TestClass1
    {
        public int Id { get; set; }
        public string Name1 { get; set; }
    }
    public class TestClass2
    {
        public int Id { get; set; }
        public string Name2 { get; set; }
    }
    static void Main()
    {
        // define some example-data
        List<TestClass1> list1 = new List<TestClass1>()
        {
            new TestClass1() { Id = 1, Name1 = "One1" },
            new TestClass1() { Id = 2, Name1 = "Two1" },
            new TestClass1() { Id = 3, Name1 = "Three1" }
        };
        List<TestClass2> list2 = new List<TestClass2>()
        {
            new TestClass2() { Id = 1, Name2 = "One2" },
            new TestClass2() { Id = 2, Name2 = "Two2" },
            new TestClass2() { Id = 3, Name2 = "Three2" }
        };
        // Here the 'magic' happens:
        // We perform a join one our 1st list
        // We send list2 as list to join with
        // We define two key-selectors in lambda-expressions: t1 => t1.Id and t2 => t2.Id
        // We form the joined object as anonymous type: (t1, t2) => new { Id = t1.Id, Name1 = t1.Name1, Name2 = t2.Name2}
        var joinedList = list1.Join(
            list2,
            t1 => t1.Id,
            t2 => t2.Id,
            (t1, t2) => new { Id = t1.Id, Name1 = t1.Name1, Name2 = t2.Name2 }
            );
        foreach (var item in joinedList)
        {
            Console.WriteLine("Id: {0}, Name1: {1}, Name2: {2}", item.Id, item.Name1, item.Name2);
        }
    }

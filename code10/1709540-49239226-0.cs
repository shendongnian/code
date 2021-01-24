    static void Main(string[] args)
    {
        // Build the object
        List<Dictionary<int, TestObject>> list = new List<Dictionary<int, TestObject>>();
        // fill it with dictionaries
        list.Add(new List<TestObject>()
        {
            new TestObject(){ Id = 1, Name = "One" },
            new TestObject() { Id = 2, Name = "Two" },
            new TestObject() { Id = 3, Name = "Three" }
        }.ToDictionary(d => d.Id));
        list.Add(new List<TestObject>()
        {
            new TestObject() { Id = 2, Name = "Two" },
            new TestObject() { Id = 3, Name = "Three" }
        }.ToDictionary(d => d.Id));
        list.Add(new List<TestObject>()
        {
            new TestObject(){ Id = 1, Name = "One" },
            new TestObject() { Id = 2, Name = "Two" }
        }.ToDictionary(d => d.Id));
        // Let's build a single list to work with
        IEnumerable<TestObject> completeList = list.SelectMany(s => s.Values);
        // aaaand filter it
        IEnumerable<TestObject> filteredList = completeList.Where(l => l.Id == 1);
    }
    public class TestObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class P
    {
        P(int id, string name) // sad, we are not getting Primary Constructors in C# 6.0
        {
            ID = id;
            Name = id;
        }
        int ID { get; }
        int Name { get; }
        static void Main(string[] args)
        {
            var items = new[] { new P(1, "Jack"), new P(2, "Jill"), new P(3, "Peter") };
            var dict = items.ToDictionary(x => x.ID, It);
        }
    }

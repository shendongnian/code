    class DictionaryComparer : IEqualityComparer<Dictionary<int, int>>
    {
        public bool Equals(Dictionary<int, int> x, Dictionary<int, int> y)
        {
            return x.Count == y.Count && !x.Except(y).Any();
        }
        public int GetHashCode(Dictionary<int, int> obj)
        {
            int hash = 17;
            foreach (var kvp in obj)
            {
                int h = EqualityComparer<KeyValuePair<int,int>>.Default.GetHashCode(kvp);
                if (h != 0)
                    hash = unchecked(hash * h);
            }
            return hash;
        }
    }
    class Thing
    {
        public int Id { get; set; }
        public int NameId { get; set; }
        public int ValueId { get; set; }
        public Thing(int id, int nameId, int valueId)
        {
            Id = id;
            NameId = nameId;
            ValueId = valueId;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Thing[]
            {
                new Thing(1,       1,       4),
                new Thing(1,       10,      18),
                new Thing(1,       9,       15),
                new Thing(2,       1,       4),
                new Thing(2,       10,      17),
                new Thing(2,       9,       0),
                new Thing(3,       1,       5),
                new Thing(3,       9,       16),
                new Thing(3,       10,      18),
                new Thing(4,       1,       5),
                new Thing(4,       10,      18),
                new Thing(4,       9,       16),
                new Thing(5,       1,       4),
                new Thing(5,       10,      17),
                new Thing(5,       9,       0),
            };
            var @as = data.GroupBy(x => x.Id)
                .Select(x => new {Id = x.Key, Data = x.ToDictionary(t => t.NameId, t => t.ValueId)})
                .GroupBy(x => x.Data, x => x.Id, new DictionaryComparer());
            foreach (var a in @as)
            {
                Console.WriteLine("{0} {1}", string.Join(",", a), string.Join(",", a.Key.Values));
            }
            Console.ReadKey();
        }
    }

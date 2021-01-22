    public class CompositeKey : Tuple<string, int>
    {
        public CompositeKey(string name, int age)
            : base(name, age)
        {
        }
        public string Name { get { return Item1; } }
        public int Age { get { return Item2; } }
    }

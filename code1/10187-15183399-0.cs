    public class Statistic<T> : Tuple<string, T>
    {
        public Statistic(string name, T value) : base(name, value) { }
        public string Name { get { return this.Item1; } }
        public T Value { get { return this.Item2; } }
    }

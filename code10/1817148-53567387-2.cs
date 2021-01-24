    public class Tuple3Int : Tuple<int, int, int> 
    {
        public Tuple3Int(int a, int b, int c) : base(a, b, c) { }
        public override string ToString()
        {
            return $"{Item1} {Item2} {Item3}";
        }
    }
    public static IEnumerable<Tuple3Int> TripletsWithSum(int sum)
    {
        return Enumerable.Range(1, sum - 1)
                         .SelectMany(a => Enumerable.Range(a + 1, sum - a - 1)
                                                    .Select(b => new Tuple3Int(a, b, sum - a - b)))
                         .Where(x => x.Item1 * x.Item1 + x.Item2 * x.Item2 == x.Item3 * x.Item3);
    }

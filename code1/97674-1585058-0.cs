    static void Main()
    {
        var solution = PermuteLength(4)
            .Where(p => Decimal.Floor(p.Value) == p.Value)
            .Where(p => p.Value <= 10 && p.Value >= 0)
            .OrderBy(p => p.Value);
        foreach (var p in solution)
        {
            Console.WriteLine(p.Formula + " = " + p.Value);
        }
    }
    public static Operator[] Operators = new[]
        {
            new Operator {Format = "({0} + {1})", Function = (x, y) => x + y},
            new Operator {Format = "({0} - {1})", Function = (x, y) => x - y},
            new Operator {Format = "({1} - {0})", Function = (x, y) => y - x},
            new Operator {Format = "({0} * {1})", Function = (x, y) => x * y},
            new Operator {Format = "({0} / {1})", Function = (x, y) => y == 0 ? 0 : x / y},
            new Operator {Format = "({1} / {0})", Function = (x, y) => x == 0 ? 0 : y / x},
        };
    public static IEnumerable<Permutation> BasePermutation = new[] { new Permutation {Formula = "5", Value = 5m} };
    private static IEnumerable<Permutation> PermuteLength(int length)
    {
        if (length <= 1)
            return BasePermutation;
        var result = Enumerable.Empty<Permutation>();
        for (int i = 1; i <= length / 2; i++)
            result = result.Concat(Permute(PermuteLength(i), PermuteLength(length - i)));
        return result;
    }
    private static IEnumerable<Permutation> Permute(IEnumerable<Permutation> left, IEnumerable<Permutation> right)
    {
        IEnumerable<IEnumerable<IEnumerable<Permutation>>> product = left.Select(l => right.Select(r => ApplyOperators(l, r)));
        var aggregate =
            product.Aggregate(Enumerable.Empty<IEnumerable<Permutation>>(), (result, item) => result.Concat(item)).
                Aggregate(Enumerable.Empty<Permutation>(), (result, item) => result.Concat(item));
        return aggregate;
    }
    private static IEnumerable<Permutation> ApplyOperators(Permutation left, Permutation right)
    {
        return Operators.Select(o => new Permutation
        {
            Formula = string.Format(o.Format, left.Formula, right.Formula),
            Value = o.Function(left.Value, right.Value)
        });
    }
    public struct Permutation
    {
        public string Formula;
        public decimal Value;
    }
    public struct Operator
    {
        public string Format;
        public Func<decimal, decimal, decimal> Function;
    }

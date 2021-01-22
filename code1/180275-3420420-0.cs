    static void TestLinqExcept()
    {
        var seqA = Enumerable.Range(1, 10);
        var seqB = Enumerable.Range(1, 7);
        var seqAexceptB = seqA.Except(seqB, new IntComparer());
        foreach (var x in seqAexceptB)
        {
            Console.WriteLine(x);
        }
    }
    class IntComparer: EqualityComparer<int>
    {
        public override bool Equals(int x, int y)
        {
            return x == y;
        }
        public override int GetHashCode(int x)
        {
            return x;
        }
    }

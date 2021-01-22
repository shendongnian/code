    static class StructuralExtensions
    {
        public static bool StructuralEquals<T>(this T a, T b)
            where T : IStructuralEquatable
        {
            return a.Equals(b, StructuralComparisons.StructuralEqualityComparer);
        }
        public static int StructuralCompare<T>(this T a, T b)
            where T : IStructuralComparable
        {
            return a.CompareTo(b, StructuralComparisons.StructuralComparer);
        }
    }
    {
        var a = new[] { 1, 2, 3 };
        var b = new[] { 1, 2, 3 };
        Console.WriteLine(a.Equals(b)); // False
        Console.WriteLine(a.StructuralEquals(b)); // True
    }
    {
        var a = new[] { 1, 3, 3 };
        var b = new[] { 1, 2, 3 };
        Console.WriteLine(a.StructuralCompare(b)); // 1
    }

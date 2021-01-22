    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Equamatics
    {
    public static class Combinatorics
    {
        #region Permute
        public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> Input, int r = -1)
        {
            int n = Input.Count();
            if (r == -1) foreach (var item in new Permutor<T>(Input).Recursion(0))
                    yield return item;
            if (r > n) throw new ArgumentOutOfRangeException("r cannot be greater than no of elements");
            foreach (var list in Input.Combinations(r))
                foreach (var item in new Permutor<T>(list).Recursion(0))
                    yield return item;
        }
        
        class Permutor<T>
        {
            int ElementLevel = -1;
            int[] PermutationValue;
            T[] Elements;
            public Permutor(IEnumerable<T> Input)
            {
                Elements = Input.ToArray();
                PermutationValue = new int[Input.Count()];
            }
            public IEnumerable<IEnumerable<T>> Recursion(int k)
            {
                ElementLevel++;
                PermutationValue[k] = ElementLevel;
                if (ElementLevel == Elements.Length)
                {
                    List<T> t = new List<T>();
                    foreach (int i in PermutationValue) t.Add(Elements[i - 1]);
                    yield return t;
                }
                else
                    for (int i = 0; i < Elements.Length; i++)
                        if (PermutationValue[i] == 0)
                            foreach (IEnumerable<T> e in Recursion(i))
                                yield return e;
                ElementLevel--;
                PermutationValue[k] = 0;
            }
        }
        public static double P(int n, int r)
        {
            if (r < 0 | n < 0 | n < r) return Double.NaN;
            else if (r == 0) return 1;
            else if (n == r) return Factorial(n);
            else
            {
                double Product = 1;
                for (int i = n - r + 1; i <= n; ++i) Product *= i;
                return Product;
            }
        }
        #endregion
        #region Combinations
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> Input, int r = -1)
        {            
            if (r == -1)
            {
                yield return Input;
                yield break;
            }
            int n = Input.Count();
            if (r > n) throw new ArgumentOutOfRangeException("r cannot be greater than no of elements");
            int[] Indices = Enumerable.Range(0, r).ToArray();
            yield return Indices.Select(k => Input.ElementAt(k));
            while (true)
            {
                int i;
                for (i = r - 1; i >= 0; --i)
                    if (Indices[i] != i + n - r)
                        break;
                if (i < 0) break;
                Indices[i] += 1;
                for (int j = i + 1; j < r; ++j)
                    Indices[j] = Indices[j - 1] + 1;
                yield return Indices.Select(k => Input.ElementAt(k));
            }
        }
        
        public static double C(int n, int r)
        {
            if (r < 0 | n < 0 | n < r) return Double.NaN;
            else if (n - r == 1 | r == 1) return n;
            else if (n == r | r == 0) return 1;
            else if (n - r > r) return (P(n, n - r) / Factorial(n - r));
            else return (P(n, r) / Factorial(r));
        }
        #endregion
        public static double Factorial(int n)
        {
            if (n < 0) return Double.NaN;
            else if (n == 0) return 1;
            else
            {
                double Product = 1;
                for (int i = 1; i <= n; ++i) Product *= i;
                return Product;
            }
        }
        public static int Derangement(int n)
        {
            double x = 0;
            for (int i = 2; i <= n; ++i)
            {
                if (i % 2 == 0) x += (1 / Factorial(i));
                else x -= (1 / Factorial(i));
            }
            return (int)(Factorial(n) * x);
        }
        public static int Catalan(int n) { return (int)C(2 * n, n) / (n + 1); }
    }
    }
`

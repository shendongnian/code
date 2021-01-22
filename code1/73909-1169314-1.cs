    using System;
    using System.Collections.Generic;
    using System.Linq;
    class EnumTwoLists
    {
        static void Main(string[] args)
        {
            var left = new List<int>();
            var right = new List<DateTime>();
            var demo = new LinqAbuse<int, DateTime>(left, right);
            demo.Populate(40, s => s * s, d => new DateTime(2009, d / 31 + 1, d % 31 + 1));
            demo.Enumerate( (s, d) => Console.WriteLine(String.Format("Executing arbitrary code with {0} and {1}", s, d)) );
        }
    }
    class LinqAbuse<T1, T2>
    {
        public LinqAbuse(List<T1> l, List<T2> r)
        {
            left = l;
            right = r;
        }
        List<T1> left;
        List<T2> right;
        public void Populate(int size, Func<int, T1> leftGenerator, Func<int, T2> rightGenerator)
        {
            new int[size].Aggregate(0, (index, empty) => PopulateWrapper(left, right, leftGenerator, rightGenerator, index));
        }
        int PopulateWrapper(List<T1> left, List<T2> right, Func<int, T1> leftGenerator, Func<int, T2> rightGenerator, int index)
        {
            left.Add(leftGenerator(index));
            right.Add(rightGenerator(index));
            return ++index;
        }
        
        public void Enumerate(Action<T1, T2> loopBody)
        {
            left.Join(right, l => "", r => "",
                      (l, r) => ActionWrapper(l, r, loopBody),
                      new CartesianComparer<object>(right.Count))
                .ToList();
        }        
        object ActionWrapper(T1 x, T2 y, Action<T1, T2> action)
        {
            action(x, y);
            return null;
        }
    }
    class CartesianComparer<T> : IEqualityComparer<T>
    {        
        public CartesianComparer(int _size)
        {
            size = _size;
            equalsCounter = (size * (size - 1) >> 1) + size; // Combinations(size, 2) + (size - trueCounter)
        }
        private int size;
        private int equalsCounter;
        private int trueCounter = 0;
        public bool Equals(T x, T y)
        {
            if (0 < --equalsCounter)
                return false;
                        
            equalsCounter = size - ++trueCounter;
            return true;
        }
        public int GetHashCode(T obj)
        {            
            return 0;
        }       
    }

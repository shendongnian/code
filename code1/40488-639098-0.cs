    using System;
    using System.Collections.Generic;
    using System.Linq;
    static class Program
    {
        static void Main()
        {
            // first and second are logically equivalent
            SimpleTableRow<int> first = new SimpleTableRow<int>(1, 2, 3, 4, 5, 6),
                second = new SimpleTableRow<int>(1, 2, 3, 4, 5, 6);
    
            if (first.Equals(second) && first.GetHashCode() != second.GetHashCode())
            { // proven Equals, but GetHashCode() disagrees
                Console.WriteLine("We have a problem");
            }
            HashSet<SimpleTableRow<int>> set = new HashSet<SimpleTableRow<int>>();
            set.Add(first);
            set.Add(second);
            // which confuses anything that uses hash algorithms
            if (set.Count != 1) Console.WriteLine("Yup, very bad indeed");
        }
    }
    class SimpleTableRow<T> : IEquatable<SimpleTableRow<T>>
    {
        
        public SimpleTableRow(int id, params T[] values) {
            this.Id = id;
            this.Values = values;
        }
        public int Id { get; private set; }
        public T[] Values { get; private set; }
        
        public override int GetHashCode() // wrong
        {
            return Id.GetHashCode() ^ Values.GetHashCode();
        }
        /*
        public override int GetHashCode() // right
        {
            int hash = Id;
            if (Values != null)
            {
                hash = (hash * 17) + Values.Length;
                foreach (T t in Values)
                {
                    hash *= 17;
                    if (t != null) hash = hash + t.GetHashCode();
                }
            }
            return hash;
        }
        */
        public override bool Equals(object obj)
        {
            return Equals(obj as SimpleTableRow<T>);
        }
        public bool Equals(SimpleTableRow<T> other)
        {
            // Check for null
            if (ReferenceEquals(other, null))
                return false;
    
            // Check for same reference
            if (ReferenceEquals(this, other))
                return true;
    
            // Check for same Id and same Values
            return Id == other.Id && Values.SequenceEqual(other.Values);
        }
    }

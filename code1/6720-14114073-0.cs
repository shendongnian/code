    using System;
    using System.Collections.Generic;
    
    namespace CDiggins
    {
        interface IPriorityQueue<T, K> where K : IComparable<K>
        {
            bool Empty { get; }
            void Enqueue(T x, K key);
            void Dequeue();
            T Top { get; }
        }
    
        class PriorityQueue<T, K> : IPriorityQueue<T, K> where K : IComparable<K>
        {
            SortedSet<Tuple<T, K>> set;
    
            class Comparer : IComparer<Tuple<T, K>> {
                public int Compare(Tuple<T, K> x, Tuple<T, K> y) {
                    return x.Item2.CompareTo(y.Item2);
                }
            }
    
            PriorityQueue() { set = new SortedSet<Tuple<T, K>>(new Comparer()); }
            public bool Empty { get { return set.Count == 0;  } }
            public void Enqueue(T x, K key) { set.Add(Tuple.Create(x, key)); }
            public void Dequeue() { set.Remove(set.Max); }
            public T Top { get { return set.Max.Item1; } }
        }
    }

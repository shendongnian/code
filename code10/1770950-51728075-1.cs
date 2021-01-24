    public sealed class PredicateCollection<T> : ICollection<Predicate<T>>
    {
        #region PredicateCollection
        private List<Predicate<T>> Predicates { get; set; }
        public PredicateCollection() { Predicates = new List<Predicate<T>>(); }
        #endregion
        #region ICollection<Predicate<T>>
        public int Count { get { return Predicates.Count; } }
        public bool IsReadOnly { get { return false; } }
        public void Add(Predicate<T> item) { Predicates.Add(item); }
        public void Clear() { Predicates.Clear(); }
        public bool Contains(Predicate<T> item) { return Predicates.Contains(item); }
        public void CopyTo(Predicate<T>[] array, int arrayIndex) { Array.Copy(Predicates.ToArray(), 0, array, arrayIndex, Count); }
        public IEnumerator<Predicate<T>> GetEnumerator() { return Predicates.GetEnumerator(); }
        public bool Remove(Predicate<T> item) { return Predicates.Remove(item); }
        IEnumerator IEnumerable.GetEnumerator() { return Predicates.GetEnumerator(); }
        #endregion
        #region PredicateCollection methods
        /// <summary>Check if any predicate is true</summary>
        public bool CheckAny(T item) { return Predicates.Any(predicate => predicate(item)); }
        /// <summary>Check if all predicates are true</summary>
        public bool CheckAll(T item) { return Predicates.All(predicate => predicate(item)); }
        /// <summary>Count how many predicates are true</summary>
        public int CountTrue(T item) { return Predicates.Count(predicate => predicate(item)); }
        /// <summary>Count how many predicates are false</summary>
        public int CountFalse(T item) { return Predicates.Count(predicate => !predicate(item)); }
        /// <summary>Count true predicates while predicates are true</summary>
        public int CountWhileTrue(T item) { int count = 0; foreach (Predicate<T> predicate in Predicates) if (predicate(item)) count++; else break; return count; }
        /// <summary>Count false predicates while predicates are false</summary>
        public int CountWhileFalse(T item) { int count = 0; foreach (Predicate<T> predicate in Predicates) if (predicate(item)) break; else count++; return count; }
        #endregion
    }

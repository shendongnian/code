    static class Extensions
    {
        public static void Sort<T, TKey>(this ObservableCollection<T> collection, Func<ObservableCollection<T>, TKey> sort)
        {
            var sorted = (sort.Invoke(collection) as IOrderedEnumerable<T>).ToArray();
            for (int i = 0; i < sorted.Count(); i++)
                collection.Move(collection.IndexOf(sorted[i]), i);
        }
    }

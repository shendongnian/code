        public static void Sort<TSource, TKey>(this ObservableCollection<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null) return;
            Comparer<TKey> comparer = Comparer<TKey>.Default;
            
            for (int i = source.Count - 1; i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    TSource o1 = source[j - 1];
                    TSource o2 = source[j];
                    if (comparer.Compare(keySelector(o1), keySelector(o2)) > 0)
                    {
                        source.Remove(o1);
                        source.Insert(j, o1);
                    }
                }
            }
        }

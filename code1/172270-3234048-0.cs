    static double Search(List<KeyValuePair<double, double>> list, double key)
    {
         int index = list.BinarySearch(new KeyValuePair<double, double>(key, new Comparer());
         // Case 1
         if (index >= 0)
             return list[index].Value;
         // NOTE: if the search fails, List<T>.BinarySearch returns the 
         // bitwise complement of the insertion index that would be used
         // to keep the list sorted.
         index = ~index;
         // Case 2
         if (index == 0 || index == list.Count)
            return 0;
         // Case 3
         return (list[index].Value + list[index + 1].Value) / 2;
    }
            
    sealed class Comparer : IComparer<KeyValuePair<double, double>>
    {
        public int Compare(KeyValuePair<double, double> x, KeyValuePair<double, double> y)
        {
             return x.Key.CompareTo(y.Key);
        }
    }
    

    public static class MyEnumerable
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            var result = new ObservableCollection<T> ();
            foreach (var item in source)
               result.Add(item);
            return result;
        }
     }

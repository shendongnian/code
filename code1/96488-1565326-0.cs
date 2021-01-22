    public static class MyEnumerable
    {
        public static ObservableCollection<T> ToObservableCollection(this IEnumerable<T> source)
        {
            var result = new ObservableCollection<T> ();
            for (var x in source)
               result.Add(p);
            return result;
        }
     }

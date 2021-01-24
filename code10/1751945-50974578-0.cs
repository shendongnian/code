    public static class CommonMethods
    {
        public static ObservableCollection<T> sort<T>(ObservableCollection<T> array, Func<T, object> key)
        {
            var res = array.AsEnumerable().OrderByDescending(key); ;
            ObservableCollection<T> temp = new ObservableCollection<T>(res);
            return temp;
        }
    }

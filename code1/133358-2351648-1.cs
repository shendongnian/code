    public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
    {
      ObservableCollection<T> obsColl = new ObservableCollection<T>();
      foreach (T element in source)
      {
        obsColl.Add( element );
      }
      return obsColl;
    }

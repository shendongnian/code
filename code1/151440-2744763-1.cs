    private static ObservableCollection<T> DeepCopy(ObservableCollection<T> list)
        where T : ICloneable
    {
       ObservableCollection<T> newList = new ObservableCollection<T>();
       foreach (T rec in list)
       {
           newList.Add((T)rec.Clone());
       }
       return newList;
    }

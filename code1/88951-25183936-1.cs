    public static TrulyObservableCollection<T> ToTrulyObservableCollection<T>(this List<T> list)
         where T : INotifyPropertyChanged
    {
        var newList = new TrulyObservableCollection<T>();
        if (list != null)
        {
            list.ForEach(o => newList.Add(o));
        }
        return newList;
    }  

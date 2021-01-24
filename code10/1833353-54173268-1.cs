    public static ObservableCollection<T> GetList<T>() where T : IEntity
    {
        ObservableCollection<T> result = new ObservableCollection<T>();
        IEntity employee = new Common.Employee();
        result.Add(employee);
        return result;
    }

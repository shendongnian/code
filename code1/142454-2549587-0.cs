    Type  GetType<T>(Table<T> table)
    {
        return typeof(T);
    }
    var table = new DataContext().TABLE1s; // this is Table<TABLE1>  
    var tableType = GetType(table);

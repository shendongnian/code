    if (typeof(T) == typeof(User))
    {
        return db.GetView<UserActive>().AsQueryable<UserActive>();
    }
    else
    {
        return db.GetTable<T>().AsQueryable<T>();
    }

    public void IncludeProperties<T>(
        Expression<Func<T,object>> selectedProperties)
    {
        // some logic to store parameter   
    }
    IncludeProperties<IUser>( u => new { u.ID, u.LogOnName, u.HashedPassword });

    protected T initializeMe<T>(T entity, Value value)
    {
      Type eType = entity.GetType();
      foreach (PropertyInfo pi in eType.GetProperties())
            {
                //get  and nsame of the column in DataRow              
                Type valueType = pi.GetType();                
                if (value != System.DBNull.Value )
                {
                 pi.SetValue(entity, value, null);
                }
                else if (valueType.IsGenericType && typeof(Nullable<>).IsAssignableFrom(valueType)) //checking if nullable can be assigned to proptety
                {
                 pi.SetValue(entity, null, null);
                }
                else
                {
                 System.Diagnostics.Trace.WriteLine("something here");
                }
                ...
            }
    ...
    }

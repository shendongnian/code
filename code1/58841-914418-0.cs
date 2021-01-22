    private TPopulateAddressObject(object o, DataRow dataRow, Type type, string idColumnName) where T : IDataStorable, new()
    {
        IDataStorable instance = (IDataStorable)AppDomain.CurrentDomain.CreateInstanceAndUnwrap(type.Assembly.FullName, type.FullName);
        PropertyInfo[] proplist = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
    
        T obj = new T();
    
        Guid id = new Guid(dataRow[idColumnName].ToString());
        string view = ReflectionHelper.GetAttribute<DBObjectRetrieveAttribute>(type).View;
    
        string query = string.Format("select * from {0} where id = '{1}'", view, id);
    
        obj = DataAccess.Retriever.Retrieve<T>(query);
        return obj;
    }

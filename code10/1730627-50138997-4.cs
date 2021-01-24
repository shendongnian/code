    MyContext db = new MyContext();
    var resultsList = new List<object>();
    PropertyInfo[] info = db.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
    foreach(PropertyInfo item in info)
    {
       //Check for array, that it is a DbSet etc...
       var setType = item.PropertyType.GetTypeInfo().GenericTypeArguments[0];
       resultsList.AddRange(db.Set(setType).ToListAsync().Result);
    }
    return resultsList;

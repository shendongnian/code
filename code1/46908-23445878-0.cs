    public TA As<TA>() where TA : Base
    {
        var type = typeof (TA);
        var instance = Activator.CreateInstance(type);
        
         PropertyInfo[] properties = type.GetProperties();
         foreach (var property in properties)
         {
             property.SetValue(instance, property.GetValue(this, null), null);
         }
          
         return (TA)instance;
    }

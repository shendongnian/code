    using System.Reflection;
    MyObject obj = new MyObject();
    PropertyInfo prop = obj.GetType().GetProperty("Name", BindingFlags.Public | BindingFlags.Instance);
    if(null != prop && prop.CanWrite)
    {
        prop.SetValue(obj, "Value", null);
    }

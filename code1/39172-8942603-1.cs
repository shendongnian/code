    using System.Reflection;
    ...
        string prop = "name";
        PropertyInfo pi = myObject.GetType().GetProperty(prop);
        pi.SetValue(myObject, "Bob", null);

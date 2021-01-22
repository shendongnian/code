    using System.Reflection;
    MyObject obj = new MyObject();
    obj.GetType().InvokeMember("Name",
        BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
        Type.DefaultBinder, obj, "Value");

    using System.Reflection;
    
    var type = typeof(YourStaticClass);
    var customstring = type.InvokeMember
    (
        "methodname",
        BindingFlags.InvokeMethod,
        Type.DefaultBinder,
        null,
        null
    );

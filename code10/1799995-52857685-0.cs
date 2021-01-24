    using System.Reflection;
    [AttributeUsage(AttributeTargets.Class)]
    class HelloAttribute : Attribute { }
    [Hello]
    class Hello1 { }
    [Hello]
    class Hello2 { }

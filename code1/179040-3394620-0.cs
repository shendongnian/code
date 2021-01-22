    using System.Linq;
    using System.Reflection;
    var methods = foo
        .GetType()
        .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
        .Where(m => m.IsFamily || m.IsPublic);

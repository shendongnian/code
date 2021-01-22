var mytype = TypeConverter<ICommand>.FromString("CreateCustomer");
Code:
 c#
    public class TypeConverter<BaseType>
        {
            private static Dictionary<string, Type> _types;
            private static object _lock = new object();
            public static Type FromString(string typeName)
            {
                if (_types == null) CacheTypes();
                if (_types.ContainsKey(typeName))
                {
                    return _types[typeName];
                }
                else
                {
                    return null;
                }
            }
            private static void CacheTypes()
            {
                lock (_lock)
                {
                    if (_types == null)
                    {
                        // Initialize the myTypes list.
                        var baseType = typeof(BaseType);
                        var typeAssembly = baseType.Assembly;
                        var types = typeAssembly.GetTypes().Where(t => 
                            t.IsClass && 
                            !t.IsAbstract && 
                            baseType.IsAssignableFrom(t));
                        _types = types.ToDictionary(t => t.Name);
                    }
                }
            }
        }
Obviously you could tweak the CacheTypes method to inspect all assemblies in the AppDomain, or other logic that better fits your use-case.  If your use-case allows for types to be loaded from multiple namespaces, you might want to change the dictionary key to use the type's `FullName` instead.  Or if your types don't inherit from a common interface or base class, you could remove the `<BaseType>` and change the CacheTypes method to use something like `.GetTypes().Where(t => t.Namespace.StartsWith("MyProject.Domain.Model.")`

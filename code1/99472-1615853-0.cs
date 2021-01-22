    static void WreakHavoc<T>(Action<T> havok)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var implementing = from assembly in assemblies
                           from type in assembly.GetTypes()
                           let interfaceType = typeof(T)
                           where interfaceType.IsAssignableFrom(type)
                           select type;
        
        foreach(var type in implementing)
        {
            var ctor = type.GetConstructor(Type.EmptyTypes);
            if (ctor == null) continue;
            var instance = (T)ctor.Invoke(new object[0]);
            havok(instance);
        }
    }
    static void Main()
    {
        WreakHavoc<System.Collections.IEnumerable>((e) =>
        {
            foreach (var o in e)
            {
                Console.WriteLine(o);
            }
        });
    }

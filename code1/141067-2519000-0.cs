    using System.Linq;    
    public static class Extensions
    {
        public static Type[] GetTopLevelInterfaces(this Type t)
        {
            Type[] allInterfaces = t.GetInterfaces();
            var inheritedInterfaces = new List<Type>();
            inheritedInterfaces.AddRange(t.BaseType.GetInterfaces());
            foreach( var intf in allInterfaces)
                inheritedInterfaces.AddRange(intf.GetInterfaces());
            var selection = allInterfaces.Except(inheritedInterfaces);
            return selection.ToArray();
        }
    }

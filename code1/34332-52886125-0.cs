    // in later .NETs, you can cache reflection extensions using a static generic class and
    // a ConcurrentDictionary. E.g.
    //public static class Attributes<T> where T : Attribute
    //{
    //    private static readonly ConcurrentDictionary<MemberInfo, IReadOnlyCollection<T>> _cache =
    //        new ConcurrentDictionary<MemberInfo, IReadOnlyCollection<T>>();
    //
    //    public static IReadOnlyCollection<T> Get(MemberInfo member)
    //    {
    //        return _cache.GetOrAdd(member, GetImpl, Enumerable.Empty<T>().ToArray());
    //    }
    //    //GetImpl as per code below except that recursive steps re-enter via the cache
    //}
    public static List<T> GetAttributes<T>(this MemberInfo member) where T : Attribute
    {
        // determine whether to inherit based on the AttributeUsage
        // you could add a bool parameter if you like but I think it defeats the purpose of the usage
        var usage = typeof(T).GetCustomAttributes(typeof(AttributeUsageAttribute), true)
            .Cast<AttributeUsageAttribute>()
            .FirstOrDefault();
        var inherit = usage != null && usage.Inherited;
        return (
            inherit
                ? GetAttributesRecurse<T>(member)
                : member.GetCustomAttributes(typeof (T), false).Cast<T>()
            )
            .Distinct()  // interfaces mean duplicates are a thing
            // note: attribute equivalence needs to be overridden. The default is not great.
            .ToList();
    }
    private static IEnumerable<T> GetAttributesRecurse<T>(MemberInfo member) where T : Attribute
    {
        // must use Attribute.GetCustomAttribute rather than MemberInfo.GetCustomAttribute as the latter
        // won't retrieve inherited attributes from base *classes*
        foreach (T attribute in Attribute.GetCustomAttributes(member, typeof (T), true))
            yield return attribute;
        // The most reliable target in the interface map is the property get method.
        // If you have set-only properties, you'll need to handle that case. I generally just ignore that
        // case because it doesn't make sense to me.
        PropertyInfo property;
        var target = (property = member as PropertyInfo) != null ? property.GetGetMethod() : member;
        foreach (var @interface in member.DeclaringType.GetInterfaces())
        {
            // The interface map is two aligned arrays; TargetMethods and InterfaceMethods.
            var map = member.DeclaringType.GetInterfaceMap(@interface);
            var memberIndex = Array.IndexOf(map.TargetMethods, target); // see target above
            if (memberIndex < 0) continue;
            // To recurse, we still need to hit the property on the parent interface.
            // Why don't we just use the get method from the start? Because GetCustomAttributes won't work.
            var interfaceMethod = property != null
                // name of property get method is get_<property name>
                // so name of parent property is substring(4) of that - this is reliable IME
                ? @interface.GetProperty(map.InterfaceMethods[memberIndex].Name.Substring(4))
                : (MemberInfo) map.InterfaceMethods[memberIndex];
            // Continuation is the word to google if you don't understand this
            foreach (var attribute in interfaceMethod.GetAttributes<T>())
                yield return attribute;
        }
    }

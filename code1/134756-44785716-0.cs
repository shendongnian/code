    private static readonly Hashtable accessors = new Hashtable();
    private static readonly Hashtable callSites = new Hashtable();
    private static CallSite<Func<CallSite, object, object>> GetCallSiteLocked(string name) {
        var callSite = (CallSite<Func<CallSite, object, object>>)callSites[name];
        if(callSite == null)
        {
            callSites[name] = callSite = CallSite<Func<CallSite, object, object>>.Create(
                        Binder.GetMember(CSharpBinderFlags.None, name, typeof(AccessorCache),
                    new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
        }
        return callSite;
    }
    internal static Func<dynamic,object> GetAccessor(string name)
    {
        Func<dynamic, object> accessor = (Func<dynamic, object>)accessors[name];
        if (accessor == null)
        {
            lock (accessors )
            {
                accessor = (Func<dynamic, object>)accessors[name];
                if (accessor == null)
                {
                    if(name.IndexOf('.') >= 0) {
                        string[] props = name.Split('.');
                        CallSite<Func<CallSite, object, object>>[] arr = Array.ConvertAll(props, GetCallSiteLocked);
                        accessor = target =>
                        {
                            object val = (object)target;
                            for (int i = 0; i < arr.Length; i++)
                            {
                                var cs = arr[i];
                                val = cs.Target(cs, val);
                            }
                            return val;
                        };
                    } else {
                        var callSite = GetCallSiteLocked(name);
                        accessor = target =>
                        {
                            return callSite.Target(callSite, (object)target);
                        };
                    }
                    accessors[name] = accessor;
                }
            }
        }
        return accessor;
    }
    public static IOrderedEnumerable<dynamic> OrderBy(this IEnumerable<dynamic> source, string property)
    {
        return Enumerable.OrderBy<dynamic, object>(source, AccessorCache.GetAccessor(property), Comparer<object>.Default);
    }
    public static IOrderedEnumerable<dynamic> OrderByDescending(this IEnumerable<dynamic> source, string property)
    {
        return Enumerable.OrderByDescending<dynamic, object>(source, AccessorCache.GetAccessor(property), Comparer<object>.Default);
    }
    public static IOrderedEnumerable<dynamic> ThenBy(this IOrderedEnumerable<dynamic> source, string property)
    {
        return Enumerable.ThenBy<dynamic, object>(source, AccessorCache.GetAccessor(property), Comparer<object>.Default);
    }
    public static IOrderedEnumerable<dynamic> ThenByDescending(this IOrderedEnumerable<dynamic> source, string property)
    {
        return Enumerable.ThenByDescending<dynamic, object>(source, AccessorCache.GetAccessor(property), Comparer<object>.Default);
    }

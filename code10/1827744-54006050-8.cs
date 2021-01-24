    private static object GetProperty(dynamic target, string name)
    {
        var site =
            CallSite<Func<CallSite, dynamic, object>>  
              .Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, name, target.GetType(),
                    new[] {CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)}));
        return site.Target(site, target);
    }
    public static object LookUpAlt(List<dynamic> lst, string propName, object value)
    {
        return lst.FindAll(i => GetProperty(i, propName).Equals(value));
    }

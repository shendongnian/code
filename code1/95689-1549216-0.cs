    var topLevel = assembly.GetTypes()
                           .Select(t => GetTopLevelNamespace(t))
                           .Distinct();
    ...
    static string GetTopLevelNamespace(Type t)
    {
        string ns = t.Namespace ?? "";
        int firstDot = ns.IndexOf('.');
        return firstDot == -1 ? ns : ns.Substring(0, firstDot);
    }

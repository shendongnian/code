    public static IEnumerable<Type> GetAllSubclassOf(Type parent)
    {
        foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            foreach (var t in a.GetTypes())
                if (t.IsSubclassOf(parent)) yield return t;
    }

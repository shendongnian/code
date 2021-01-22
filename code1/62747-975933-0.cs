    foreach (var obj in CPE.Components.ToList())
    {
        obj.Context.Load();
        foreach (var child in obj.Context.ToList()) { obj.Context.Remove(child); }
        CPE.DeleteObject(obj);
    }

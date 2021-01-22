    //...
    #if WINDOWS_UWP
    using System.Reflection;
    #endif
    //...
        
    public void CloneIn<T>(T src, T dest)
    {
    #if WINDOWS_UWP
        var props = typeof(T).GetTypeInfo().DeclaredProperties.Where(p => !p.GetIndexParameters().Any());
    #else
        var props = typeof(T).GetProperties().Where(p => !p.GetIndexParameters().Any());
    #endif
        foreach (var prop in props)
        {
            if(prop.SetMethod!=null)
                prop.SetValue(dest, prop.GetValue(src));
        }
    }

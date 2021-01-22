    public static R Map<T, R>(this T t, Func<T, R> func)
    {
        return func(t);
    }
    
    ExpensiveFindWally().Map(wally=>wally.FirstName + " " + wally.LastName)
    
    public static R TryCC<T, R>(this T t, Func<T, R> func)
        where T : class
        where R : class
    {
        if (t == null) return null;
        return func(t);
    }
    
    public static R? TryCS<T, R>(this T t, Func<T, R> func)
        where T : class
        where R : struct
    {
        if (t == null) return null;
        return func(t);
    }
    
    public static R? TryCS<T, R>(this T t, Func<T, R?> func)
        where T : class
        where R : struct
    {
        if (t == null) return null;
        return func(t);
    }
    
    public static R TrySC<T, R>(this T? t, Func<T, R> func)
        where T : struct
        where R : class
    {
        if (t == null) return null;
        return func(t.Value);
    }
    
    public static R? TrySS<T, R>(this T? t, Func<T, R> func)
        where T : struct
        where R : struct
    {
        if (t == null) return null;
        return func(t.Value);
    }
    
    public static R? TrySS<T, R>(this T? t, Func<T, R?> func)
        where T : struct
        where R : struct
    {
        if (t == null) return null;
        return func(t.Value);
    }
    
    //int? bossNameLength =  Departament.Boss.TryCC(b=>b.Name).TryCS(s=>s.Length);
    
    
    public static T ThrowIfNullS<T>(this T? t, string mensaje)
        where T : struct
    {
        if (t == null)
            throw new NullReferenceException(mensaje);
        return t.Value;
    }
    
    public static T ThrowIfNullC<T>(this T t, string mensaje)
        where T : class
    {
        if (t == null)
            throw new NullReferenceException(mensaje);
        return t;
    }
    
    public static T Do<T>(this T t, Action<T> action)
    {
        action(t);
        return t;
    }
    
    //Button b = new Button{Content = "Click"}.Do(b=>Canvas.SetColumn(b,2));
    
    public static T TryDo<T>(this T t, Action<T> action) where T : class
    {
        if (t != null)
            action(t);
        return t;
    }
    
    public static T? TryDoS<T>(this T? t, Action<T> action) where T : struct
    {
        if (t != null)
            action(t.Value);
        return t;
    }

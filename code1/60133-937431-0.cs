    public struct CookieData<T>
        where T : Object
    {
        T Value { get; set; }
        DateTime Expires { get; set; }
    }

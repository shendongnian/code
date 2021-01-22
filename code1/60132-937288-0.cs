    public interface ICookieData
    {
      // you need this to get the value without knowing it's type
      object UntypedValue { get; }
      // whatever you need additionally ...
      Type DataType { get; } 
    
      DateTime Expires { get; set; }
    }
    
    public struct CookieData<T> : ICookieData
    {
        // ICookieData implementation
        public object UntypedValue { get { return Value; } }
        public Type DataType { get { return typeof(T); } }
        public DateTime Expires { get; set; }
        // generic implementation
        T Value { get; set; }
    }
    
    public interface ICookieService2: IDictionary<string, ICookieData>
    {
       // ...
    }
    
    CookieData<int> intCookie = { Value = 27, Expires = DateTime.Now };
    CookieData<string> stringCookie = { Value = "Bob", Expires = DateTime.Now };
    
    CookieService2 cs = new CookieService2();
    cs.Add(intCookie);
    cs.Add(stringCookie);

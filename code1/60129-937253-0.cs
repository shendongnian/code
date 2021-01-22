    public interface ICookieDataBase
    {
        DateTime Expires { get; set; }
    }
    public struct CookieData<T> : ICookieDataBase
    {
        public T Value { get; set; }
        public DateTime Expires { get; set; }
    }
    public class ICookieService : IDictionary<string, ICookieDataBase>
    {
        // ...
    }
    public void DoWork()
    {
        var intCookie =
            new CookieData<int> { Value = 27, Expires = DateTime.Now };
        var stringCookie =
            new CookieData<string> { Value = "Bob", Expires = DateTime.Now };
        ICookieService cs = GetICookieService();
        cs.Add(intCookie);
        cs.Add(stringCookie);
    }

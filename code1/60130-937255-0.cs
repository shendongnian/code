    public interface ICookieData
    {
        object Value {get;} // if you need to be able to set from CookieService, life gets harder, but still doable.
        DateTime Expires {get;}
    }
    
    public class CookieDate<T> : ICookieData
    {
        T Value {get;set;}
        DateTime Expires {get;set;}
    
        object ICookieData.Value
        {
            get
            {
                return Value;
            }
        }
    }

    public object GetValue(string name, DynamicFunc func)
    {
        return func.DynamicInvoke("a", "b");
    }
    public class DynamicFunc
    {
        public Func<object> None { get; private set; }
        public Func<object, object> One {get; private set;}
        public Func<object, object, object> Two { get; private set; }
        public object DynamicInvoke(object param1 = null, object param2 = null)
        {
            if (Two != null)
                return Two(param1, param2);
            else if (One != null)
                return One(param1 ?? param2);
            else if (None != null)
                return None();
            return null;
        }
        public static implicit operator DynamicFunc(Func<object> func)
            => new DynamicFunc { None = func };
        public static implicit operator DynamicFunc(Func<object, object> func)
            => new DynamicFunc { One = func };
        public static implicit operator DynamicFunc(Func<object, object, object> func)
            => new DynamicFunc { Two = func };
    }

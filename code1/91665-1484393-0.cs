    [DebuggerDisplay("IsDefined:{IsDefined}, Value:{_Value}")]
    public sealed class Undefined<T>
    {
        public static Undefined<T>[] DeserializeArray(string jsonArray)
        {
            var jss = new JavaScriptSerializer();
            var objs = jss.Deserialize<object[]>(jsonArray);
            var undefinedArray = new Undefined<T>[objs.Length];
            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i] is Dictionary<string, object>)
                {
                    var undefined = (Dictionary<string, object>)objs[i];
                    if (undefined.ContainsKey("undefined") && undefined["undefined"] == null)
                    {
                        undefinedArray[i] = new Undefined<T>(default(T), false);
                        continue;
                    }
                }
                T val;
                // The object being must be serializable by the JavaScriptSerializer
                // Or at the very least, be convertible from one type to another
                // by implementing IConvertible.
                try
                {
                    val = (T)objs[i];
                }
                catch (InvalidCastException)
                {
                    val = (T)Convert.ChangeType(objs[i], typeof(T));
                }
                undefinedArray[i] = new Undefined<T>(val, true);
            }
            return undefinedArray;
        }
        private Undefined(T value, bool isDefined)
        {
            Value = value;
            IsDefined = isDefined;
        }
        public static explicit operator T(Undefined<T> value)
        {
            if (!value.IsDefined)
                throw new InvalidCastException("Value is undefined. Unable to cast.");
            return value.Value;
        }
        public bool IsDefined { get; private set; }
        private T _Value;
        public T Value
        {
            get
            {
                if (IsDefined)
                    return _Value;
                throw new Exception("Value is undefined.");
            }
            private set { _Value = value; }
        }
        public override bool Equals(object other)
        {
            Undefined<T> o = other as Undefined<T>;
            if (o == null)
                return false;
            if ((!this.IsDefined && o.IsDefined) || this.IsDefined && !o.IsDefined)
                return false;
            return this.Value.Equals(o.Value);
        }
        public override int GetHashCode()
        {
            if (IsDefined)
                return Value.GetHashCode();
            return base.GetHashCode();
        }
        public T GetValueOrDefault()
        {
            return GetValueOrDefault(default(T));
        }
        public T GetValueOrDefault(T defaultValue)
        {
            if (IsDefined)
                return Value;
            return defaultValue;
        }
        public override string ToString()
        {
            if (IsDefined)
                Value.ToString();
            return base.ToString();
        }
    } 

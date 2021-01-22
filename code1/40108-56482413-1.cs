    public abstract  class EnumType<T>  where T : EnumType<T>   
    {
    
        public  string Value { get; set; }
    
        protected EnumType(string value)
        {
            Value = value;
        }
    
    
        public static implicit operator EnumType<T>(string s)
        {
            if (All.Any(dt => dt.Value == s))
            {
                Type t = typeof(T);
    
                ConstructorInfo ci = t.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,null, new Type[] { typeof(string) }, null);
    
                return (T)ci.Invoke(new object[] {s});
            }
            else
            {
                return null;
            }
        }
    
        public static implicit operator string(EnumType<T> dt)
        {
            return dt?.Value;
        }
    
    
        public static bool operator ==(EnumType<T> ct1, EnumType<T> ct2)
        {
            return (string)ct1 == (string)ct2;
        }
    
        public static bool operator !=(EnumType<T> ct1, EnumType<T> ct2)
        {
            return !(ct1 == ct2);
        }
    
    
        public override bool Equals(object obj)
        {
            try
            {
                return (string)obj == Value;
            }
            catch
            {
                return false;
            }
        }
    
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    
        public static IEnumerable<T> All
         => typeof(T).GetProperties()
           .Where(p => p.PropertyType == typeof(T))
           .Select(x => (T)x.GetValue(null, null));
       
    
        
    }

    public class DateTimeWrapper
        {
            private DateTime _value = DateTime.Now;
    
            public DateTime Value
            {
                get { return _value; }
                set { _value = value; }
            }
    
            public static implicit operator DateTime(DateTimeWrapper wrapper)
            {
                if (wrapper == null) return DateTime.Now;
                return wrapper.Value;
            }
    
            public static implicit operator DateTimeWrapper(DateTime date)
            {
                return new DateTimeWrapper { Value = date };
            }
        }

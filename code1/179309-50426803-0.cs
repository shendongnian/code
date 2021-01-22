    public class a<based>
        {
            public static implicit operator b(a<based> v)
            {
                return new b();
            }
        }
    
        public class b
            : a<b>
        {
        }

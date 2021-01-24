     public abstract  class StringType<T> where T :StringType<T>,new()
    {
        [ReadOnly(true)]
        public string Value;
        public T FromString(string d)
        {
            return  new T
            {
                Value = d
            };
            
        }
        public override bool Equals(object obj)
        {
            return obj?.ToString() == Value;
        }
        public override int GetHashCode()
        {
            
            return Value.GetHashCode();
        }
        public override string ToString()
        {
           
            return Value;
        }
     
    }

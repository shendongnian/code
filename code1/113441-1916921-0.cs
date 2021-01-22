    public class NullableDictionnary<T1, T2> : Dictionary<T1, T2>
    {
        T2 null_value;
    
        public T2 this[T1 key]
        {
            get
            {
                if (key == null)
                { return null_value; }
                return base[key];
            }
            set
            {
                if (key == null)
                { null_value = value; }
                else
                { base[key] = value; }
            }
        }
    }

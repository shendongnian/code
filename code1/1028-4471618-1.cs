    public class TypedProperty<T> : Property
    {
        public T TypedValue
        {
            get { return (T)(object)base.Value; }
            set { base.Value = value.ToString();}
        }
    }

    public class TypedProperty<T> : Property
    {
        public T TypedValue
        {
            get { return (T)Convert.ChangeType(base.Value, typeof(T)); }
            set { base.Value = value.ToString();}
        }
    }

    public class TypedProperty<T> : Property where T : IConvertible
    {
        public T TypedValue
        {
            get
            {
                if (base.Value == null) return default(T);
                var type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
                return (T)Convert.ChangeType(base.Value, type);
            }
            set { base.Value = value.ToString(); }
        }
    }

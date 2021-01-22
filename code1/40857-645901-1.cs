    public class DBValue<T>
    {
        public static implicit operator DBValue <T>(T value)
        {
             return new DBValue<T>(value);
        }
        public static explicit operator T(DBValue <T> dbValue)
        {
             return dbValue.Value;
        }
        private readonly T _value;
        public T Value { get { this._value; } }
    
        public DBValue(T value)
        {
             this._value = value;
        }
    }

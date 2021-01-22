    public class MyClass
    {
        private readonly Dictionary<Type, Func<SomeResult, object>> _map = 
            new Dictionary<Type, Func<SomeResult, object>> ();
        public MyClass ()
        {
            _map.Add (typeof (int), o => return SomeTypeSafeMethod ((int)(o)));
        }
        public SomeResult DoSomething<T>(T numericValue)
        {
            Type valueType = typeof (T);
            if (!_map.Contains (valueType))
            {
                throw new NotSupportedException (
                    string.Format (
                    "Does not support Type [{0}].", valueType.Name));
            }
            SomeResult result = _map[valueType] (numericValue);
            return result;
        }
    }

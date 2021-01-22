        public class UnclosedMethod
        {
            private readonly MethodInfo _method;
            public UnclosedMethod(Type type, string method)
            {
                _method = type.GetMethod(method);
            }
            public T Invoke<T>(string name)
            {
                var fact = _method.MakeGenericMethod(typeof(T));
                return (T)fact.Invoke(this, new object[] { name });
            }
        }

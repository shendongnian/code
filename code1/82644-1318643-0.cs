    public class MyClass<TClass> where TClass: struct
    {
        private TClass _Instance;
        
        public MyClass(TClass instance)
        {
            _Instance = instance;
        }
        
        public TMethod ConvertTo<TMethod>()
        {
            return (TMethod)Convert.ChangeType(_Instance, typeof(TMethod));
        }
    }

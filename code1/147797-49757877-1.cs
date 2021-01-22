    public abstract class SingletonBase<T> where T : class
    {
        private static readonly Lazy<T> _Lazy = new Lazy<T>(() =>
        {
            // Get non-public constructors for T.
            var ctors = typeof(T).GetConstructors(System.Reflection.BindingFlags.Instance |
                                                  System.Reflection.BindingFlags.NonPublic);
            if (!Array.Exists(ctors, (ci) => ci.GetParameters().Length == 0))
                throw new InvalidOperationException("Non-public ctor() was not found.");
            var ctor = Array.Find(ctors, (ci) => ci.GetParameters().Length == 0);
            // Invoke constructor and return resulting object.
            return ctor.Invoke(new object[] { }) as T;
        }, System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);
        public static T Instance
        {
            get { return _Lazy.Value; }
        }
    }
Notice that it uses Lazy<T> to create a field _Lazy that knows how to instantiate a class using it's private constructor.
And it defines one Property Instance to access the Value of the Lazy field.
Notice the LazyThreadSafetyMode enum that is passed to the Lazy constructor. It is using ExecutionAndPublication. So only one thread will be allowed to initialize the Value of the Lazy field.

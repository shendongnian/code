    public abstract class BaseLazySingleton<T> where T : class
        {
            private static readonly Lazy<T> LazyInstance =
                new Lazy<T>(CreateInstanceOfT, LazyThreadSafetyMode.ExecutionAndPublication);
    
            #region Properties
            public static T Instance
            {
                get { return LazyInstance.Value; }
            }
            #endregion
    
            #region Methods
            private static T CreateInstanceOfT()
            {
                return Activator.CreateInstance(typeof(T), true) as T;
            }
    
            protected BaseLazySingleton()
            {
            }
    
            #endregion
        }

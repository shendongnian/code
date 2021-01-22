    public abstract class MyBase
    {    
        protected MyBase()
        {
            if (Initialize(this)) // just to illustrate; this will never pass here as this class is abstract
                this.Start();
        }
        protected bool IsInitialized { get; private set; } = false;
        protected static bool Initialize<T>(T instance) where T: MyBase
        {
            if (instance?.GetType() == typeof(T)) // check if this is called from the constructor of instance run time type
                return instance.IsInitialized || ( instance.IsInitialized = instance.Initialize() );
            return false;
        }
        protected abstract bool Initialize();
        public abstract void Start();
    }

    public sealed class Singleton
    {
        static private readonly WeakReference _instanceReference =
            new WeakReference(Singleton.LoadInstance());
        static public Singleton Instance
        {
            get { return Singleton.GetInstance(); }
        }
    
        static private Singleton() { }
        static private Singleton LoadInstance()
        {
            // load from expensive resource;
            return new Singleton();
        }
        static private Singleton GetInstance()
        {
            Singleton result = _instanceReference.Target as Singleton;
            if (result == null)
            {
                // TODO: consider thread safety
                result = LoadInstance();
                _instanceReference.Target = result;
            }
            return result;
        }
    
        private Singleton()
        {
            //
        }
    
    }

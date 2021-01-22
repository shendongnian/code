    public abstract class Base { ... }
 
    public class Impl : Base { ... }
    public class Singleton : Impl
    { 
        #region Static Members
        static readonly Singleton _instance = new Singleton(); 
 
        static Singleton() { } 
 
        static public Singleton Instance 
        { 
            get  { return _instance; } 
        } 
        #endregion Static Members
        #region Instance Members
        private Singleton() { } 
        // Method overrides goes here...
        #endregion Instance Members
    } 

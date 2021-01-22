    class MyClass
    {
      // ...
      #region Singleton pattern
      private MyClass() { }
      public static MyClass Instance { get { return Singleton.instance; } }
      class Singleton
      {
        static Singleton() { }
        internal static readonly MyClass instance = new MyClass();
      }
      #endregion
      // ...
    }
    

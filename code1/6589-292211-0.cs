    class MyConcreteClass
    {
      #region Singleton Implementation
        
        public static readonly Instance = new MyConcreteClass();
        
        private MyConcreteClass(){}
        
      #endregion
        
        /// ...
    }

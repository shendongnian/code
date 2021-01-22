    static ComWrapper<ComType> WrapComObject<ComType>(ComType comObject) where ComType : class
    {
        return new ComWrapper<ComType>(comObject);
    }
    
    class ComWrapper<ComType> : IDisposable where ComType : class
    {
        public ComWrapper(ComType comObject)
        {
            Object = comObject;
        }
    
        public ComType Object { get; private set;  }
    
        #region IDisposable Members
    
        public void Dispose()
        {
            if (Object != null)
            {
                Marshal.ReleaseComObject(Object);
                Object = null;
            }
        }
    
        #endregion
    }

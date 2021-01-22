    {    
        #region fields
    
        private Engine _engine;
    
        #endregion
    
        #region public properties
    
        public Engine carEngine { get { return _engine; } set { _engine = value; } }  
    
        #endregion 
    
        #region constructors 
    
        public Car(Engine e)    
        { 
            _engine = e; 
        }
    
        #endregion
    }

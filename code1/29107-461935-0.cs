    public class Car
    {    
        #region fields
         
        private Engine _engine;
       
        #endregion
       
        #region public properties
       
        public Engine Engine { get { return _engine; } set { _engine = value; } }  
    
        #endregion 
    
        #region constructors 
    
        public Car(Engine engine)    
        { 
            _engine = engine; 
        }
    
        #endregion
    }

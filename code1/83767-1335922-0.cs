    #if USE_FLOAT
    using Numeric = System.Single;
    #endif
    
    #if USE_DOUBLE
    using Numeric = System.Double;
    #endif
    
    #if USE_DECIMAL
    using Numeric = System.Decimal;
    #endif
    
    public class SomeClass
    {
        public Numeric MyValue{get;set;}
    }

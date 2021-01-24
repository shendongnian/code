    public class DisplayWhenAttribute : Attribute
    {
        private string _propertyName;
        private int _condition1;
        private int _condition2;
        private string _trueValue;
        private string _falseValue;
    
        public string PropertyName 
        {
           get
           {
               return _propertyName;
           }
        }
    
        public int Condition1
        {
           get
           {
               return _condition1;
           }
        }
    
        public int Condition2
        {
           get
           {
               return _condition2;
           }
        }
    
        public string TrueValue
        {
           get
           {
               return _trueValue;
           }
        }
    
        public string FalseValue
        {
           get
           {
               return _falseValue;
           }
        }
    
        public DisplayWhenAttribute(string propertyName, int condition1, int condition2, string trueValue, string falseValue)
        {
            _propertyName = propertyName;
            _condition1 = condition1;
            _condition2 = condition2;
            _trueValue = trueValue;
            _falseValue = falseValue;
        }
    }

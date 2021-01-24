    public class Parameter<T>
    {
        private string mParameterName;
        private T parameterValue; // runtime parameter
    
        public Parameter( string parameterName, T parameterValue )
        {
            this.mParameterName = parameterName;
            //this. is required below because the method parameter and class member
            //have the same name, so this. refers to the class member and without
            //refers to the method parameter.
            this.parameterValue = parameterValue;
        }
    }

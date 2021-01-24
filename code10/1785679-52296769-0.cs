    public class Parameter<T> where T : struct
    {
        private string mParameterName;
        private T parameterValue; // runtime parameter
    
        public Parameter( string parameterName, T parameterValue ){}
    }

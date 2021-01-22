    class ParameterHelper
    {
       private object value;
       public ParameterHelper(object value)   { this.value = value;  }
    
       public static implicit operator int(ParameterHelper v)
         { return (int) v.value; }
    
    }
    ParameterHelper GetParameterValue( string parameterName);
    MyObj.SomeProp = GetParameterValue("parameterName");

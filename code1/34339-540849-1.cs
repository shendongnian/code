    [DataContract()]
    [KnownType( "GetKnownType" )]
    public class Variable
    {
    
     public object Value;
    
     private static Type[] GetKnownType()
     {
       // properties
       return new []{ typeof(VariableBool),
                      typeof(VariableLong), 
                      typeof(VariableDouble),};
     }
    }
    
    [DataContract()]
    public class VariableBool : Variable
    {
    }
    
    [DataContract()]
    public class VariableLong : Variable
    {
    }
    
    [DataContract()]
    public class VariableDouble : Variable
    {
    }

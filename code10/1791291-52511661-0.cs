     public struct ParameterNameValuePair<TParameterName, TValue>
     {
         // implement constructor to assign values
         public ParameterNameValuePair(TParameterName parameterName, TValue value)
         {
             ParameterName = parameterName;
             Value = value;
         }
         public TParameterName ParameterName { get; }
         public TValue Value { get; }
         // implement ToString() to return a meaningful string representation
         public override string ToString() => $"[{Key}]: {Value}";
     }

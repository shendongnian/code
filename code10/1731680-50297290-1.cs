     public class ResponseDestructuringPolicy : IDestructuringPolicy
     {
       public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory, out LogEventPropertyValue result)
       {
         if (value is IResponse response)
         {
           result = propertyValueFactory.CreatePropertyValue( new {response.Message} );
           return true;
         }
         result = null;
         return false;
       }
    }

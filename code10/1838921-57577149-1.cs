        interface IEnumerableSignatures
        {
          ...
          void GroupBy(object selector);
          void Select(object selector);
          void ToList();
          ...
        }
        Expression ParseAggregate(Expression instance, Type elementType, string methodName, int errorPos)
        {
           ...
           if (signature.Name == "Min" || 
               signature.Name == "Max" || 
               signature.Name == "GroupBy" || 
               signature.Name == "Select")
           ...
        }

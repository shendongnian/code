        interface IEnumerableSignatures
        {
          ...
          void Select(object selector);
          void ToList();
          ...
        }
        Expression ParseAggregate(Expression instance, Type elementType, string methodName, int errorPos)
        {
           ...
           if (signature.Name == "Min" || 
               signature.Name == "Max" || 
               signature.Name == "Select")
           ...
        }

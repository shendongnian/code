    // A silly example. default(T) will return null if it is nullable. So no reason to check here. Except for the sake of having an example.
    public U AssignValueOrDefault<U>(object item)
    {
        if (item == null)
        {
            Type type = typeof(U); // Type from Generic Parameter
            // Basic Types like int, bool, struct, ... can't be null
            //   Except int?, bool?, Nullable<int>, ...
            bool notNullable = type.IsValueType ||
                               (type.IsGenericType && type.GetGenericTypeDefinition() != typeof(Nullable<>)));
    
            if (notNullable)
                return default(T);
        }
        
        return (U)item;
    }
   

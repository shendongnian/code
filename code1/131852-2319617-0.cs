    static Type GetEnumerableType(Type type)  
    {  
        if(type.IsA<IEnumerable<>>) {  
            {  
                return type.GetGenericArguments()[0];  
            }  
        }  
        return null;  
    }

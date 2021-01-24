                Type genericClass = typeof(CustomRepository<>).MakeGenericType(_typeObject);
                var invokeObject = validationContext.GetService(genericClass);
    
                var parameters = new object [] { value, "username" };
                MethodInfo method = genericClass.GetMethod("IsValid");
                object getCheck = method.Invoke(invokeObject, parameters);

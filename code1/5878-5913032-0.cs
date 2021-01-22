    // Check if the exception is serializable and also the specific ones if generic
    var exceptionType = ex.GetType();
    var allSerializable = exceptionType.IsSerializable;
    if (exceptionType.IsGenericType)
        {
            Type[] typeArguments = exceptionType.GetGenericArguments();
            allSerializable = typeArguments.Aggregate(allSerializable, (current, tParam) => current & tParam.IsSerializable);
        }
     if (!allSerializable)
        {
            // Create a new Exception for not serializable exceptions!
            ex = new Exception(ex.Message);
        }

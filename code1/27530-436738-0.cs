    MethodInfo method = typeof(Foo).GetMethod("ConvertToListOfObjects",
        BindingFlags.Static | BindingFlags.Public);
    Type listType = list.GetType().GetGenericArguments()[0];
    MethodInfo concrete = method.MakeGenericMethod(new [] { listType });
    List<object> objectList = (List<object>) concrete.Invoke(null, 
                                                       new object[]{list});

    object obj = new object();
    MyType typObj = new MyType();
    obj = typObj;
    Type objType = typObj.GetType();
    
    Type listType = typeof(List<>);
    Type creatableList = listType.MakeGenericType(objType);
    
    object list = Activator.CreateInstance(creatableList);
    MethodInfo mi = creatableList.GetMethod("Add");
    mi.Invoke(list, new object[] {obj});

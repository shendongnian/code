    string name = "LinqObjectName";
    int primaryKey = 123;
    
    var dc = new YourDataContext();
                
    Type dcType = dc.GetType();
    Type type = dcType.Assembly.GetType(String.Format("{0}.{1}", dcType.Namespace, name));
    
    MethodInfo methodInfoOfMethodToExcute = dc.GetType().GetMethod("GetInstanceByPrimaryKey");
    MethodInfo methodInfoOfTypeToGet = methodInfoOfMethodToExcute.MakeGenericMethod(name);
    var instance = methodInfoOfTypeToGet.Invoke(dc, new object[] { primaryKey });
                
    return instance;

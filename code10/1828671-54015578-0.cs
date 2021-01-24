    static void Action1(Object obj)
    {
      //do necessary casting here or not
      Console.WriteLine("i handle Type1");
    }
    static void Action2(Object obj)
    {
       Console.WriteLine("i handle Type2");
    }
    Dictionary<Type, Action<Object>> methodMap = new Dictionary<Type, Action<Object>>();
    methodMap[typeof(Type1)] = Action1;
    methodMap[typeof(Type2)] = Action2;

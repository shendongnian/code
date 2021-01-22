    Class1 c = new Class1();
    Type class1Type = c.GetType();
    MethodInfo callMeMethod = class1Type.GetMethod("CallMe", BindingFlags.Instance | BindingFlags.NonPublic);
    int result = (int)callMeMethod.Invoke(c, null);
    Console.WriteLine(result);

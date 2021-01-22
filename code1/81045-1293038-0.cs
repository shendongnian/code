    CallStaticMethod("MainApplication.Test", "Test1");
    
    public  static void CallStaticMethod(string typeName, string methodName)
    {
        var type = Type.GetType(typeName);
        if (type != null)
        {
            var method = type.GetMethod(methodName);
            if (method != null)
            {
                method.Invoke(null, null);
            }
        }
    }
    public static class Test
    {
        public static void Test1()
        {
            Console.WriteLine("Test invoked");
        }
    }

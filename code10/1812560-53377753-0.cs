    public void ExecuteDynamicMethod(int number)
    {
        // Modify these two lines with your app's dll/exe and class type:
        Assembly assembly = Assembly.LoadFile("...Assembly1.dll");
        Type type = assembly.GetType("YourClassType");
        if (type != null)
        {
            MethodInfo methodInfo = type.GetMethod("function" + number);
            if (methodInfo != null)
            {
                object classInstance = Activator.CreateInstance(type, null);
                methodInfo.Invoke(classInstance, null);  // null = "no function arguments"
            }
        }
    }

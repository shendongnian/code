    public static void TryCommand(Expression<Func<MyClass,bool>> command, MyClass c)
    {
        // Code as before to find the method name etc.
        Func<MyClass, bool> compiled = command.Compile();
        if (!compiled(c))
        {
            Console.WriteLine(methodCallExpression.Method.Name
                + "() failed with error code " + c.GetError());
        }
    }

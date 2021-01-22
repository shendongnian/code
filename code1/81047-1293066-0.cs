    public void MyFunction()
    {
        string dotSeparatedParams = "Myclass.Method";
        string[] arrayParams = dotSeparatedParams.Split('.');
        // since the class was defined in the string, start with loading it
        Type classType = Type.GetType(arrayParams[0]);
        if( classType == null )
            throw new Exception();
        // load the reference to the method
        MethodInfo mi = classType.GetMethod(arrayParams[1]);
        if (mi == null)
            throw new Exception();
        // call the method
        mi.Invoke(null, null);
    }

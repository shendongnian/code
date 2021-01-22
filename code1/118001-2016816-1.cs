    public Class1()
    {
        string callingClass = new StackFrame(1).GetMethod().DeclaringType.Name;
    
        if (callingClass != "Class2")
        {
            throw new ApplicationException(
                string.Concat("Class1 constructor can not be called by ",
                callingClass, "."));
        }
    }

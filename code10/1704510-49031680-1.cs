    public static TestDataFile GetAttribute()
    {
        var callingMethod = new StackFrame(1).GetMethod();
        var attribute = (TestDataFile)callingMethod.GetCustomAttributes(typeof(TestDataFile), false).FirstOrDefault();
        return attribute;
    }

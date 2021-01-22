    public static Type GetType()
    {
        var stack = new System.Diagnostics.StackTrace();
        if (stack.FrameCount < 2)
            return null;
        return (stack.GetFrame(1).GetMethod() as System.Reflection.MethodInfo).DeclaringType;
    }

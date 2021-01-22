    public static Type GetActionDelegateType(params Type[] typeArgs)
    {
        var argCount = typeArgs.Length;
        if (argCount == 0) return typeof (Action);
        var defType = argCount == 1
            ? typeof (Action<>) //special case since it's found in mscorlib
            : Type.GetType(string.Format("System.Action`{0}, {1}",
                argCount,
                typeof (Action).Assembly.FullName));
        return defType.MakeGenericType(typeArgs);
    }

    public static void Entering(object obj, MethodBase methodInfo,
                                params object[] args) {
        Console.WriteLine("ENTERING {0}:{1}", methodInfo.DeclaringType.Name,
                                              methodInfo.Name);
        ...
    }

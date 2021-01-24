    public static void ForEachFieldIn<C>(C theClass, BindingFlags theFlags, Action<FieldInfo> task) where C : class
    {
        theClass.GetType()
            .GetFields(theFlags)
            .ToList()
            .ForEach(task);
    }

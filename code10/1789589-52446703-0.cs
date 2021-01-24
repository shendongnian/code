    var task = objType.GetTypeInfo()
        .GetDeclaredMethod("ThePrivateMethod")
        .Invoke(theObject, null);
    await (Task)task;
    if (task.GetType().IsGenericType)
    {
        var result = task.GetType().GetProperty("Result").GetValue(task);
        Console.WriteLine(result);
    }

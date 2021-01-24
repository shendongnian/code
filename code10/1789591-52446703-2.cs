    var task = objType.GetTypeInfo()
        .GetDeclaredMethod("ThePrivateMethod")
        .Invoke(theObject, null);
    await (Task)task;
    var taskType = task.GetType();
    if (taskType.IsGenericType && taskType.GetGenericTypeDefinition() == typeof(Task<>))
    {
        var result = taskType.GetProperty("Result").GetValue(task);
        Console.WriteLine(result);
    }

    var voidTaskResult = Type.GetType("System.Threading.Tasks.VoidTaskResult");
    if (taskType.IsGenericType
        && taskType.GetGenericTypeDefinition() == typeof(Task<>)
        && taskType.GetGenericArguments()[0] != voidTaskResult)
    {
        var result = task.GetType().GetProperty("Result").GetValue(task);
        Console.WriteLine(result);
    }

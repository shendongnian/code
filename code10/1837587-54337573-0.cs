    Type knownInRuntimeResultType = ...; // string or IEnumerable<int>
    Type taskType = typeof(Task<>).MakeGenericType(knownInRuntimeResultType); 
    Task task = ...; // e.g., Task<string> or Task<IEnumerable<int>>    
    
    // result is string or IEnumerable<int>
    object result = taskType.GetProperty("Result").GetValue(task);    

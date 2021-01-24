    var tasks = new List<Task>();
    
    Task<MyType1> myTask1 = getData01Async();
    tasks.Add(myTask1);
    
    Task<MyTyp2> myTask2 = null;
    Task<MyType3> myTask3 = null;
    
    if(myVariable == true)
    {
        myTask2 = getData02Async();
        tasks.Add(myTask2);
    }
    else
    {
        myTask3 = getData03Async();
        tasks.Add(myTask3);
    }
    await Task.WhenAll(tasks);

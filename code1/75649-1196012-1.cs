    foreach (Foo myParam in parameters)
    {
        Foo copy = myParam; // This line is crucial
        // Then we use the new variable in the anonymous method
        ThreadStart processTaskThread = delegate { ProcessTasks(copy); };
        new Thread(processTaskThread).Start();
    }

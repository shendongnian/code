    // fix method signature, this doesn't run asynchronous code so it needs not be a Task
    public IEnumerable<Task> OperateRecursively(A root)
    {
        List<Task> tasks = new List<Task>();
    
        foreach (IAorB child in root.Children)
        {
            if (child is B)
            {
                tasks.Add(SomeOperation(child));
            }
            else
            {
                // 1. change to AddRange since you are adding multiple elements, not one
                // 2. fix name for actual recursion
                // 3. cast child to A since otherwise it wouldn't compile
                tasks.AddRange(OperateRecursivelyA(child as A));
            }
        }
    
        tasks.Add(SomeOperation(root));
    
        return tasks;
    }

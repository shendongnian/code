    List<string> work = (some list with lots of strings)
    
    // Split the work in two
    List<string> odd = new List<string>();
    List<string> even = new List<string>();
    for (int i = 0; i < work.Count; i++)
    {
        if (i % 2 == 0)
        {
            even.Add(work[i]);
        }
        else
        {
            odd.Add(work[i]);
        }
    }
    
    // Set up to worker delegates
    List<Foo> oddResult = new List<Foo>();
    Action oddWork = delegate { foreach (string item in odd) oddResult.Add(CalculateSmth(item)); };
    
    List<Foo> evenResult = new List<Foo>();
    Action evenWork = delegate { foreach (string item in even) evenResult.Add(CalculateSmth(item)); };
    
    // Run two delegates asynchronously
    IAsyncResult evenHandle = evenWork.BeginInvoke(null, null);
    IAsyncResult oddHandle = oddWork.BeginInvoke(null, null);
    
    // Wait for both to finish
    evenWork.EndInvoke(evenHandle);
    oddWork.EndInvoke(oddHandle);
    
    // Merge the results from the two jobs
    List<Foo> allResults = new List<Foo>();
    allResults.AddRange(oddResult);
    allResults.AddRange(evenResult);
    
    return allResults;

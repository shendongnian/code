    IEnumerable<TestResults> AllResults(IEnumerable<TestResults> results)
    {
        var queued = new Queue<TestResult>(results); 
        while(queued.Count > 0)
        {
            var tr = queued.Dequeue();
            yield return tr;
            foreach(var sr in tr.SubTests)
                queued.Enqueue(sr);
        }
    }

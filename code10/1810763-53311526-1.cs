    public static string RunBatch()
    {
        string batch = "Re-running batch";
        Debug.WriteLine(batch);
        
        TestOutput print = new TestOutput();
        print.TestMethod();
    
        return batch;
    }
    
    public static string ProcessAdjustedBatch()
    {
        return "I have been called from the datagrid!!!!";
    }

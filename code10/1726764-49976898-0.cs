    private readonly object _resultLock = new object();    
    private string A()
    {
        var lines = new StringBuilder();
        for (int i = 0; i <= 10000; i++)
        {
            lines.AppendLine("select * from testing");
        }
        lock (_resultLock)
        {
            result += lines.ToString();
        }
    }

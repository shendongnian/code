    public static class TaskExtensions
    {
        Task Run(
            Action action,
            [CallerMemberName] string caller = null,
            [CallerFilePath] string callerFile = null,
            [CallerLineNumber] int lineNumber = 0)
        {
            tasks.Add(new Entry { ... });
            return Task.Run(action);
        }
        // etc.
    }
    class Entry
    {
        Task Task { get; set; }
        string CallerMemberName { get; set; }
        string CallerFilePath { get; set; }
        string CallerFileNumber { get; set; }
        int ThreadId { get; set; }
        DateTime Started { get; set; }
        DateTime Stopped { get; set; }
    }
    var tasks = new ConcurrentDictionary<string, Entry>();

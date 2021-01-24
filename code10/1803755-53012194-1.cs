    static async Task<ProcessResult> Convert()
    {
        var proces = new Process();
        // Configure process
        // .......
        // End configure process
    
        await proces.ExecuteAsync();
    
        return new ProcessResult
        {
            ExitCode = proces.ExitCode,
            // Set other properties
        };
    }

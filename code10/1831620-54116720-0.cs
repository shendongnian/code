    public class PSScriptException : Exception
    {
        public PSScriptException(Collection<ErrorRecord> errorRecords)
        {
            this.ErrorRecords = errorRecords;
        }
        public PSScriptException(Collection<ErrorRecord> errorRecords, string message): this(errorRecords)
        {
            this.Message = message;
        }
        Collection<ErrorRecord> ErrorRecords { public get; private set; }
    }
    public static Collection<PSObject> PowerShellLocal(string scriptBlock)
    {
        using (PowerShell powerShell = PowerShell.Create())
        {
            powerShell.AddScript(scriptBlock);
            var results = powerShell.Invoke();
            if (powerShell.Streams.Error.Count > 0)
            {
                throw new PSScriptException(powerShell.Streams.Error);
            }
               
            return results;
        }
    }
    // ...
    void DoScript(string scriptBlock)
    {
        try
        {
            Collection<PSObject> results = PowerShellLocal(scriptBlock);
            doTheThing(results);
        }
        catch (PSScriptException scriptEx)
        {
            handleTheErrors(scriptEx);
        }
    }

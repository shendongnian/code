    List<string> RunLog = new List<string>(); 
    using (System.Management.Automation.PowerShell psInstance = System.Management.Automation.PowerShell.Create())
    
    {
        psInstance.AddScript(_Script);
    psInstance.Streams.Error.DataAdded += (sender, args) =>
    {
        ErrorRecord err = ((PSDataCollection<ErrorRecord>)sender)[args.Index];
        RunLog.Add($"ERROR: {err}");
    };
    psInstance.Streams.Debug.DataAdded += (sender, args) =>
    {
        DebugRecord debug = ((PSDataCollection<DebugRecord>)sender)[args.Index];
        RunLog.Add($"DEBUG: {debug}");
    };
    psInstance.Streams.Information.DataAdded += (sender, args) =>
    {
        InformationRecord info = ((PSDataCollection<InformationRecord>)sender)[args.Index];
        RunLog.Add($"INFO: {info}");
    };
    psInstance.Streams.Progress.DataAdded += (sender, args) =>
    {
        ProgressRecord progress = ((PSDataCollection<ProgressRecord>)sender)[args.Index];
        RunLog.Add($"PROGRESS: {progress.PercentComplete}%");
    };
    psInstance.Streams.Warning.DataAdded += (sender, args) =>
    {
        WarningRecord warning = ((PSDataCollection<WarningRecord>)sender)[args.Index];
        RunLog.Add($"WARNING: {warning}");
    };
    psInstance.Streams.Verbose.DataAdded += (sender, args) =>
    {
        VerboseRecord verbose = ((PSDataCollection<VerboseRecord>)sender)[args.Index];
        RunLog.Add($"VERBOSE: {verbose}");
    };
                        
    var result = new PSDataCollection<PSObject>();
    result.DataAdded += (sender, args) =>
    {
        PSObject output = ((PSDataCollection<PSObject>)sender)[args.Index];
        RunLog.Add($"OUTPUT: {output}");
    };
    try
    {
        psInstance.Invoke(null, result);
    }
    catch(Exception ex)
    {
        RunLog.Add($"EXCEPTION: {ex.Message}");
    }                                                
    }

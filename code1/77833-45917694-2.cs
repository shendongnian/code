    List<string> RunLog = new List<string>(); 
    using (System.Management.Automation.PowerShell psInstance = System.Management.Automation.PowerShell.Create())
    
    {
        psInstance.AddScript(_Script);
    psInstance.Streams.Error.DataAdded += (sender, args) =>
    {
        ErrorRecord err = ((PSDataCollection<ErrorRecord>)sender)[args.Index];
        RunLog.Add($"ERROR: {err}");
    };
    psInstance.Streams.Warning.DataAdded += (sender, args) =>
    {
        WarningRecord warning = ((PSDataCollection<WarningRecord>)sender)[args.Index];
        RunLog.Add($"WARNING: {warning}");
    };
    ... etc ...
                        
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

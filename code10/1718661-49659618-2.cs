    using ( var run = RunspaceFactory.CreateOutOfProcessRunspace(null) )
    {
        run.Open();
        using ( _powerShell = PowerShell.Create() )
        {
            try
            {
                _powerShell.Runspace = run;
                _powerShell.AddScript($"{scriptFile} {args}");
                _powerShell.Invoke();
            }
            catch ( Exception ex )
            {
                //do stuff
            }
        }
    }
    

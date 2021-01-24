    using (var ps = PowerShell.Create())
    {
    	// commands that writes to the output
    	ps.AddScript("Write-Host 'output value'");
    	ps.Invoke();
    	var output = (ps.Streams.Information.First().MessageData as HostInformationMessage).Message;
    	Console.WriteLine(output); // output value
    }
    using (var ps = PowerShell.Create())
    {
    	// command that returns a value, e.g. a string literal
    	ps.AddScript("'return value'");
    	var results = ps.Invoke();
    	string stringResult = results.First().BaseObject as string;
    	Console.WriteLine(stringResult); // return value
    }

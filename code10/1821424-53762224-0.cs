    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    
    private DataTable getProcesses() 
    {
    	// Create the datatable and columns
    	DataTable dt = new DataTable();
    	dt.Columns.Add("ID");
    	dt.Columns.Add("Name");
    	dt.Columns.Add("Path");
    	dt.Columns.Add("User");
    	dt.Columns.Add("Priority");
    	dt.Columns.Add("BasePriority");	
    	
    	string script = $"get-process -IncludeUserName | select id, processname, path, username, priorityclass";
    	
    	List<string[]> psOutput = new List<string[]>();
    	
    	// Invoke Powershell cmdlet and get output
    	using (PowerShell ps = PowerShell.Create())
    	{
    		ps.AddScript(script);
    		var output = ps.Invoke();
    		if(ps.Streams.Error.Count > 0)
    		{
    			throw new Exception($"Error running script:{Environment.NewLine}{string.Join(Environment.NewLine, ps.Streams.Error.Select(e => e.ToString()))}");
    		}
    
    		// clean and split the output
    		psOutput.AddRange(output.Select(i => i.ToString().Replace("; ", ";").TrimStart("@{".ToCharArray()).TrimEnd('}').Split(';')));
    	}
    	
    	// populate the DataTable
    	psOutput
    		.AsParallel() 			// this does not really help when not calling Process.GetProcessById
    		.Select(p => p.Select(f => f.Split("=")).ToDictionary(k => k.FirstOrDefault(), v => v.LastOrDefault()))
    		.Select(kv => new object[] {	// "flatten" the dictionaries into object[]'s that will become the datarows
    						kv["Id"]
    						, kv["ProcessName"]
    						, kv["Path"]
    						, kv["UserName"]
    						, kv["PriorityClass"]
    						, Process.GetProcessById(int.Parse(kv["Id"])).BasePriority  // if you need the numerical base priority - takes quite a bit longer though (Not sure how to get this via Powershell)
    					}
    			)
    		.ToList()
    		.ForEach(r => dt.Rows.Add(r));  // add each object[] to the datatable
    		
    	// return the datatable 
    	return dt;
    }

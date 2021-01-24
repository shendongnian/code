    public static void Main(string[] args) {
    	foreach (var document in Directory.EnumerateDirectories(JsonFolder)) {
    		MeasureMemory(document);
    	}
    }
    
    private static void MeasureMemory(string document) {
    	// run process
    	var proc = new Process {
    		StartInfo = new ProcessStartInfo {
    			FileName = "loader.exe",
    			Arguments = document,
    			WindowStyle = ProcessWindowStyle.Hidden,
    			UseShellExecute = false,
    			RedirectStandardOutput = true,
    			CreateNoWindow = true
    		}
    	};
    	proc.Start();
    
    	// get process output
    	var output = string.Empty;
    	while (!proc.StandardOutput.EndOfStream) {
    		output += proc.StandardOutput.ReadLine() + "\n";
    	}
    
    	proc.WaitForExit();
    
    	// parse process output
    	var processMemoryBeforeLoad = long.Parse(Regex.Match(output, "BEFORE ([\\d]+)", RegexOptions.Multiline).Groups[1].Value);
    	var processMemoryAfterLoad = long.Parse(Regex.Match(output, "AFTER ([\\d]+)", RegexOptions.Multiline).Groups[1].Value);
    
    	// save the measures in a CSV file
    }

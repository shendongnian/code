    public static int Main(string[] args) {
    	var document = args[0];
    	var files = Directory.EnumerateFiles(document);
    
    	Console.WriteLine("BEFORE {0}", MeasureMemoryUsage());
    
    	wrapper.LoadFiles(files);
    	
    	Console.WriteLine("AFTER {0}", MeasureMemoryUsage());
    
    	wrapper.Unload();
    	
    	return 0;
    }
    
    private static long MeasureMemoryUsage() {
    	// make sure GC has done its job
    	GC.Collect();
    	GC.WaitForPendingFinalizers();
    	GC.Collect();
    
    	return System.Diagnostics.Process.GetCurrentProcess().VirtualMemorySize64;
    }

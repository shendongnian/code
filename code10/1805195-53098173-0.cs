    public class DebugHelper
    {
    	[DllImport("ole32.dll")]
    	static extern int GetRunningObjectTable(int reserved, out IRunningObjectTable prot);
    
    	[DllImport("ole32.dll")]
    	static extern int CreateBindCtx(int reserved, out IBindCtx ppbc);
    
    	public static bool AttachTo(params int[] processIds)
    	{
    		var notAttached = processIds.Length;
    		var maybeDebuggedProcessId = System.Diagnostics.Process.GetCurrentProcess().Id;
    
    		IRunningObjectTable runningObjectTable = null;
    		IEnumMoniker enumMoniker = null;
    		IBindCtx bindCtx = null;
    
    		try
    		{
    			CreateBindCtx(0, out bindCtx);
    			GetRunningObjectTable(0, out runningObjectTable);
    			runningObjectTable.EnumRunning(out enumMoniker);
    
    			var monikers = new IMoniker[1];
    			var numFetched = IntPtr.Zero;
    			while (enumMoniker.Next(1, monikers, numFetched) == 0)
    			{
    				monikers[0].GetDisplayName(bindCtx, null, out var runningObjectName);
    				runningObjectTable.GetObject(monikers[0], out var runningObjectVal);
    
    				if (runningObjectVal is DTE2 dte
    					&& dte.Debugger is Debugger2 debugger
    					&& runningObjectName.StartsWith("!VisualStudio.DTE.15.0"))
    				{
    					foreach (Process2 debuggedProcess in dte.Debugger.DebuggedProcesses)
    					{
    						if (debuggedProcess.ProcessID == maybeDebuggedProcessId)
    						{
    							var def = debugger.Transports.Item("Default");
    							var engines = new List<Engine>();
    							foreach (Engine engine in def.Engines)
    							{
    								engines.Add(engine);
    							}
    
    							var debugEngine = new[]
    							{
    								engines.Single(x => x.Name == "Managed (v4.6, v4.5, v4.0)")
    							};
    
    							foreach (Process2 localProcess in dte.Debugger.LocalProcesses)
    							{
    								if (processIds.Contains(localProcess.ProcessID))
    								{
    									localProcess.Attach2(debugEngine);
    									notAttached--;
    								}
    							}
    
    							break;
    						}
    					}
    				}
    			}
    			return notAttached == 0;
    		}
    		finally
    		{
    			if (bindCtx != null) Marshal.ReleaseComObject(bindCtx);
    			if (runningObjectTable != null) Marshal.ReleaseComObject(runningObjectTable);
    			if (enumMoniker != null) Marshal.ReleaseComObject(enumMoniker);
    		}
    	}
    }

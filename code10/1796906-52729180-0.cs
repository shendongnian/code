 	void CheckAndDebugBreak()
    {
        while (true)
        {
			string fileGuard = ...; // whatever file you can easily create/delete
			if (File.Exists(fileGuard))
			{
				File.Delete(fileGuard); // to avoid hitting the breakpoint next time, recreate the file if needed 
				System.Diagnostics.Debugger.Break(); 
			
				// some way to stop the infinite loop e.g.
				if (somevariableSetOutside)
					break;
				// wait a while before next check
				System.Threading.Thread.Sleep(1000);
			}
		}
    }	 

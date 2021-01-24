        void RestartIfNeeded() {
            if (!IsAdmin() {
                Process p= new Process {
    			    StartInfo = new ProcessStartInfo {
    				    FileName = Process.GetCurrentProcess().MainModule.FileName,
    				    Arguments = //parameters here,
                        //Following two lines make process start as admin
    				    Verb = "runas";
    				    UseShellExecute = true;
    		    	}
                }
                p.Start();
                p.WaitForExit();
                p.Dispose();
                Enviroment.Exit(p.ExitCode)
            }
        }
        bool IsAdmin() {
    			try {
    				return new WindowsPrincipal(WindowsIdentity.GetCurrent()) 
                        .IsInRole(WindowsBuiltInRole.Administrator);
    			}
    			catch (Exception) {
    				return false;
    			}
    		}

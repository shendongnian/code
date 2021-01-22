    using System;
    using System.Collections.Generic;
    
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    using System.Collections.ObjectModel;
    
    namespace CsWildcard {
    	class Program {
    
    		static IEnumerable<string> CmdletDirGlobbing(string basePath, string glob){
    			Runspace runspace = RunspaceFactory.CreateRunspace();
    			runspace.Open();
    			
    			// cd to basePath
    			if(basePath != null){
    				Pipeline cdPipeline = runspace.CreatePipeline();
    				Command cdCommand = new Command("cd");
    				cdCommand.Parameters.Add("Path", basePath);
    				cdPipeline.Commands.Add(cdCommand);
    				cdPipeline.Invoke(); // run the cmdlet
    			}
    			
    			// run the "dir" cmdlet (e.g. "dir C:\*\*\*.txt" )
    			Pipeline dirPipeline = runspace.CreatePipeline();
    			Command dirCommand = new Command("dir");
    			dirCommand.Parameters.Add("Path", glob);
    			dirPipeline.Commands.Add(dirCommand);
    
    			Collection<PSObject> dirOutput = dirPipeline.Invoke();
    
    			// for each found file
    			foreach (PSObject psObject in dirOutput) {
    				
    				PSMemberInfoCollection<PSPropertyInfo> a = psObject.Properties;
    				// look for the full path ("FullName")
    				foreach (PSPropertyInfo psPropertyInfo in psObject.Properties) {
    					if (psPropertyInfo.Name == "FullName") {
    						yield return psPropertyInfo.Value.ToString(); // yield it
    					}
    				}
    			}
    
    		}
    
    		static void Main(string[] args) {
    			foreach(string path in CmdletDirGlobbing(null,"C:\\*\\*\\*.txt")){
    				System.Console.WriteLine(path);
    			}
    			foreach (string path in CmdletDirGlobbing("C:\\", "*\\*\\*.exe")) {
    				System.Console.WriteLine(path);
    			}	
    			Console.ReadKey();
    		}
    
    	}
    }

     private static void WriteProcesses(StreamWriter sw, DateTime d) {
         sw.WriteLine("List of processes @ " + d.ToString());
         var localAll = Process.GetProcesses()
                               .Where(o => o.ProcessName.ToLower() != "svchost");            
         foreach(Process process in localAll) {                    
             sw.WriteLine("      " + process.ProcessName);
         }
     }

           private static void WriteProcesses(StreamWriter sw, DateTime d) {
                sw.WriteLine("List of processes @ " + d.ToString());
                var localAll = Process.GetProcesses().Where(o => o.ProcessName.ToLower() != "svchost");            
                foreach(var local in localAll) {                    
                        sw.WriteLine("      " + local.ProcessName);
                }
            }

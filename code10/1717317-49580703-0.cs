    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Management.Automation;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace PSTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (PowerShell powerShellInstance = PowerShell.Create(RunspaceMode.NewRunspace))
                {
                    
                    var script = "param($param1) $output = 'testing params in C#:' + $param1; $output";
                    powerShellInstance.AddScript(script);
                    powerShellInstance.AddParameter("param1", "ParamsinC#");
                    Collection<PSObject> PSOutput = powerShellInstance.Invoke();
    
                    foreach (PSObject outputItem in PSOutput)
                    {
                        
                        if (outputItem != null)
                        {
                            Console.WriteLine(outputItem);
                        }
                    }
                    Console.ReadKey();
    
                }
            }
        }
    }

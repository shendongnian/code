    using System;
    using System.Management.Automation;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var script = @" 
                    Get-WmiObject -list -namespace root\cimv2 | Foreach {$_.Name}
                ";
    
                var powerShell = PowerShell.Create();
                powerShell.AddScript(script);
    
                foreach (var className in powerShell.Invoke())
                {
                    Console.WriteLine(className);
                }
            }
        }
    }

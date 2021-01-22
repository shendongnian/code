    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Management.Automation;
    
    namespace RunspaceInvokeExp
    {
        class Program
        {
            static void Main()
            {
                using (var invoker = new RunspaceInvoke())
                {
                    string command = @"Get-WmiObject -list -namespace root\cimv2" +
                                      " | Foreach {$_.Name}";
                    Collection<PSObject> results = invoker.Invoke(command);
                    var classNames = results.Select(ps => (string)ps.BaseObject);
                    foreach (var name in classNames)
                    {
                        Console.WriteLine(name);
                    }
                }
            }
        }
    }

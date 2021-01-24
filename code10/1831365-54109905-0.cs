    namespace ConsoleApp2
    {
        using System;
        using System.Linq;
        using System.Management.Automation;
        using System.Management.Automation.Runspaces;
        using System.Security;
    
        class Program
        {
            static void Main(string[] args)
            {
                var script = @"
                Write-Host ""-------$env:computername-------""
                Write-Warning ""Write warning directly in warn script""
                Write-Error ""Write error directly in warn script""
                Write-Verbose ""Write verbose directly in warn script"" -verbose
                Write-Host ""Write host directly in warn script""
                Write-Information ""Write Information in warn script""
                ";
    
                SecureString password = new SecureString();
                "Password".ToCharArray().ToList().ForEach(c => password.AppendChar(c));
                PSCredential credentials = new PSCredential("UserName", password);
    
                WSManConnectionInfo connectionInfo = new WSManConnectionInfo();
                connectionInfo.ComputerName = "TargetServer";
                connectionInfo.Credential = credentials;
    
                using (var shell = PowerShell.Create())
                {
                    using (var runspace = RunspaceFactory.CreateRunspace(connectionInfo))
                    {
                        runspace.Open();
    
                        shell.Runspace = runspace;
    
                        shell.Streams.Information.DataAdded += LogProgress<InformationRecord>;
                        shell.Streams.Warning.DataAdded += LogProgress<WarningRecord>;
                        shell.Streams.Error.DataAdded += LogProgress<ErrorRecord>;
                        shell.Streams.Verbose.DataAdded += LogProgress<VerboseRecord>;
                        shell.Streams.Debug.DataAdded += LogProgress<DebugRecord>;
    
                        shell.AddScript(script);
                        shell.Invoke();
                    }
                }
    
                Console.ReadKey();
            }
    
            private static void LogProgress<T>(object sender, DataAddedEventArgs e)
            {
                var data = (sender as PSDataCollection<T>)[e.Index];
                Console.WriteLine($"[{typeof(T).Name}] {Convert.ToString(data)}");
            }
        }
    }

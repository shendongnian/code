                Console.WriteLine("Enter command to execute on your Ubuntu GNU/Linux");
                var commandToExecute = Console.ReadLine();
                // if command is null use 'ifconfig' for demo purposes
                if (string.IsNullOrWhiteSpace(commandToExecute))
                {
                    commandToExecute = "ifconfig";
                }
                // Execute wsl command:
                using (var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = @"cmd.exe",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardInput = true,
                        CreateNoWindow = true,
                    }
                })
                {
                    proc.Start();
                    proc.StandardInput.WriteLine("wsl " + commandToExecute);
                    System.Threading.Thread.Sleep(500); // give some time for command to execute
                    proc.StandardInput.Flush();
                    proc.StandardInput.Close();
                    proc.WaitForExit(5000); // wait up to 5 seconds for command to execute
                    Console.WriteLine(proc.StandardOutput.ReadToEnd());
                    Console.ReadLine();
                    
                }
         

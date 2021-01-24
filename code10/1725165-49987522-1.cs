            private static CommandStartResult StartDotnetProcess(string arguments, string workingDirectory)
            {
                var command = "dotnet";
                workingDirectory = NormalizeWorkingDirectory(workingDirectory);
                var process = PrepareProcess(command, arguments, workingDirectory);
                var createdProcesses = new List<Process>();
                var commandId = $"[{workingDirectory}] {command} {arguments}";
                try
                {
                    WriteLine(commandId);
                    createdProcesses = StartProcessAndCapture(commandId, process);
                    process.BeginOutputReadLine();
                }
                catch (Exception exc)
                {
                    WriteLine($"{commandId} : {exc}");
                    throw;
                }
                return new CommandStartResult
                {
                    MainProcess = process,
                    CreatedProcesses = createdProcesses,
                };
            }
            private static Process PrepareProcess(
                string command,
                string arguments,
                string workingDirectory
            )
            {
                var process = new Process
                {
                    EnableRaisingEvents = true,
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = command,
                        Arguments = arguments,
                        WorkingDirectory = workingDirectory,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                    },
                };
                process.ErrorDataReceived += (_, e) => handle(command, arguments, workingDirectory, "ERROR", e.Data);
                process.OutputDataReceived += (_, e) => handle(command, arguments, workingDirectory, "", e.Data);
                process.StartInfo.Environment.Add("ASPNETCORE_ENVIRONMENT", "Development");
                return process;
            }

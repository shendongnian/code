    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading;
    namespace RunE2E
    {
        public class Program
        {
            static string currentDirectory = Directory.GetCurrentDirectory();
            public static int Main(string[] args)
            {
                var serviceAlikeProcessResult = StartProcessViaCmd("node", "test.js", "");
                var serviceAlikeProcess = serviceAlikeProcessResult.MainProcess;
                var brokenWithErrorResult = StartProcessViaCmd("npm", "THIS IS NOT A REAL COMMAND, THEREFORE EXPECTED TO FAIL", "");
                var brokenWithErrorProcess = brokenWithErrorResult.MainProcess;
                brokenWithErrorProcess.Exited += (_, __) =>
                {
                    KillProcesses("Front-End", serviceAlikeProcessResult.MainProcess, serviceAlikeProcessResult.CreatedProcesses);
                    KillProcesses("E2E-Test", brokenWithErrorResult.MainProcess, brokenWithErrorResult.CreatedProcesses);
                };
                serviceAlikeProcess.WaitForExit();
                return serviceAlikeProcess.ExitCode;
            }
            private static CommandStartResult StartProcessViaCmd(string command, string arguments, string workingDirectory)
            {
                workingDirectory = NormalizeWorkingDirectory(workingDirectory);
                var process = new Process
                {
                    EnableRaisingEvents = true,
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = arguments,
                        WorkingDirectory = workingDirectory,
                        UseShellExecute = false,
                        RedirectStandardInput = true,
                        RedirectStandardError = true,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true,
                    },
                };
                var createdProcesses = new List<Process>();
                process.ErrorDataReceived += (_, e) => handle(command, arguments, workingDirectory, "ERROR", e.Data);
                process.OutputDataReceived += (_, e) => handle(command, arguments, workingDirectory, "", e.Data);
                var commandId = $"[{workingDirectory}] {command} {arguments}";
                try
                {
                    WriteLine(commandId);
                    createdProcesses = StartProcessAndCapture(commandId, process);
                    process.BeginOutputReadLine();
                    process.StandardInput.WriteLine($"{command} {arguments} & exit");
                }
                catch (Exception exc)
                {
                    WriteLine($"{commandId}: {exc}");
                    throw;
                }
                return new CommandStartResult
                {
                    MainProcess = process,
                    CreatedProcesses = createdProcesses,
                };
            }
            static List<Process> StartProcessAndCapture(string commandId, Process processToStart)
            {
                var before = Process.GetProcesses().ToList();
                var beforePidSet = new HashSet<int>(before.Select(process => process.Id));
                var _ = processToStart.Start();
                Thread.Sleep(3000);
                var after = Process.GetProcesses().ToList();
                var newlyCreatedProcessIdList = new HashSet<int>(after.Select(process => process.Id));
                newlyCreatedProcessIdList.ExceptWith(beforePidSet);
                var createdProcesses = after.Where(process => newlyCreatedProcessIdList.Contains(process.Id)).ToList();
                foreach (var process in createdProcesses)
                    WriteLine($"{commandId} ||| [{process.Id}] {process.ProcessName}", ConsoleColor.Blue);
                return createdProcesses;
            }
            static string NormalizeWorkingDirectory(string workingDirectory)
            {
                if (string.IsNullOrWhiteSpace(workingDirectory))
                    return currentDirectory;
                else if (Path.IsPathRooted(workingDirectory))
                    return workingDirectory;
                else
                    return Path.GetFullPath(Path.Combine(currentDirectory, workingDirectory));
            }
            static Action<string, string, string, string, string> handle =
                (string command, string arguments, string workingDirectory, string level, string message) =>
                {
                    var defaultColor = Console.ForegroundColor;
                    Write($"[{workingDirectory}] ");
                    Write($"{command} ", ConsoleColor.DarkGreen);
                    Write($"{arguments}", ConsoleColor.Green);
                    Write($"{level} ", level == "" ? defaultColor : ConsoleColor.Red);
                    WriteLine($": {message}");
                };
            static void KillProcesses(string prefix, Process baseProcess, List<Process> processList)
            {
                processList = baseProcess == null ?
                    processList :
                    processList.Where(process => process.Id != baseProcess.Id).Append(baseProcess).ToList();
                foreach (var process in processList)
                    KillProcess(prefix, process);
            }
            static void KillProcess(string prefix, Process process)
            {
                if (process != null && !process.HasExited)
                    try
                    {
                        WriteLine(prefix + " | Kill (" + process.ProcessName + ") [" + process.Id + "]");
                        process.Kill();
                    }
                    catch (Win32Exception win32exc)
                    {
                        WriteLine(prefix + " | Kill (" + process.ProcessName + ") [" + process.Id + "]: " + win32exc.Message);
                    }
            }
            static void WaitForExit(Process process)
            {
                while (process.HasExited == false) { }
            }
            static object console = new object();
            static void Write(string text, ConsoleColor? color = null)
            {
                lock (console)
                {
                    var original = Console.ForegroundColor;
                    Console.ForegroundColor = color.HasValue ? color.Value : original;
                    Console.Write(text);
                    Console.ForegroundColor = original;
                }
            }
            static void WriteLine(string text = null, ConsoleColor? color = null)
            {
                lock (console)
                {
                    var original = Console.ForegroundColor;
                    Console.ForegroundColor = color.HasValue ? color.Value : original;
                    Console.WriteLine(text);
                    Console.ForegroundColor = original;
                }
            }
        }
        class CommandStartResult
        {
            public Process MainProcess { get; set; }
            public List<Process> CreatedProcesses { get; set; }
        }
    }

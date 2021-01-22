     using (var env = new ProcessEnvironment(settings))
                    {
                        filePath = Path.Combine(env.WorkingDirectory, settings.ApplicationEXE);
                        var psi = new ProcessStartInfo
                        {
                            UseShellExecute = false,
                            FileName = filePath,
                            WorkingDirectory = env.WorkingDirectory,
                            Arguments = (args != null && args.Length > 0 ? String.Join(" ", args) : null)
                        };
    
                        var proc = Process.Start(psi);
    
                        if (env.ExecutingFromTempDir || settings.WaitForExit)
                            proc.WaitForExit();
                    }

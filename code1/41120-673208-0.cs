                        Process p = new Process();
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.FileName = "sqlplus";
                        p.StartInfo.Arguments = string.Format("xxx/xxx@{0} @{1}", in_database, s);
    
                        bool started = p.Start();
                        // important ... read stream input before waiting for exit.
                        // this avoids deadlock.
                        string output = p.StandardOutput.ReadToEnd();
    
                        p.WaitForExit();
    
                        Console.WriteLine(output);
    
                        if (p.ExitCode != 0)
                        {
                            Console.WriteLine( string.Format("*** Failed : {0} - {1}",s,p.ExitCode));
                            break;
                        }

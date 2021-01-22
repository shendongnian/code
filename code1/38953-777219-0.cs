    // file test.cs
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    public class Test
    {
        public static int Main()
        {
            string error;
            try {
                ProcessStartInfo i = new ProcessStartInfo();
                i.FileName = @"C:\long file path\run.cmd";
                i.WindowStyle = ProcessWindowStyle.Hidden;
                i.UseShellExecute = true;
                i.RedirectStandardOutput = false;
                using (Process p = Process.Start(i)) {
                    error = "No process object was returned from Process.Start";
                    if (p != null) {
                        p.WaitForExit();
                        if (p.ExitCode == 0) {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("OK");
                            Console.ResetColor();
                            return 0;
                        }
                        error = "Process exit code was " + p.ExitCode;
                    }
                }
            }
            catch (Win32Exception ex) {
                error = "(Win32Exception) " + ex.Message;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Whooops: " + error);
            Console.ResetColor();
            return 1;
        }
    }

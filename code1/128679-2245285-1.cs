    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    using System.Threading;
    static class Program
    {
        static void Main(string[] args)
        {
            // Are we the temporary EXE?
            string thisExePath = Process.GetCurrentProcess().MainModule.FileName;
            if (Regex.IsMatch(Path.GetFileNameWithoutExtension(thisExePath),
                              "temp.*",
                              RegexOptions.IgnoreCase))
            {
                // Delete the parent program, after giving it time to exit (args[0] is its path.)
                Thread.Sleep(1000);
                File.Delete(args[0]);
                // Do some real work!
                Console.WriteLine("Hello, World!");
            }
            else
            {
                string tempExePath =
                    Path.Combine(Path.GetTempPath(),
                                 String.Format("Temp-{0}.exe", Guid.NewGuid()));
                using (FileStream createTempExe =
                    new FileStream(tempExePath,
                                   FileMode.CreateNew,
                                   FileAccess.Write,
                                   FileShare.Read,
                                   0x1000,
                                   FileOptions.DeleteOnClose))
                {
                    byte[] thisExeBytes = File.ReadAllBytes(thisExePath);
                    createTempExe.Write(thisExeBytes, 0, thisExeBytes.Length);
                    // Open a second, read-only handle to the temporary EXE to keep it alive
                    using (FileStream readTempExe =
                        new FileStream(tempExePath,
                                       FileMode.Open,
                                       FileAccess.Read,
                                       FileShare.ReadWrite | FileShare.Delete))
                    {
                        createTempExe.Close();
                        // Pass this program's path to the child so it can delete the parent EXE
                        ProcessStartInfo childProcess = new ProcessStartInfo(tempExePath, thisExePath);
                        childProcess.UseShellExecute = false;
                        // Always throws "Access Denied" exception :-(
                        Process.Start(childProcess);
                    }
                }
            }
        }
    }

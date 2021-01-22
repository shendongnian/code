    using System;
    using System.Diagnostics;
    using System.IO;
    
    class Test {
            static void Main (string [] args)
            {
                    Process proc = new Process ();
                    proc.StartInfo.FileName = "ffmpeg";
                    proc.StartInfo.Arguments = "-i " + args [0] + " " + args [1];
                    proc.StartInfo.RedirectStandardError = true;
                    proc.StartInfo.UseShellExecute = false;
                    if (!proc.Start ()) {
                            Console.WriteLine ("Error starting");
                            return;
                    }
                    StreamReader reader = proc.StandardError;
                    string line;
                    while ((line = reader.ReadLine ()) != null) {
                            Console.WriteLine (line);
                    }
                    proc.Close ();
            }
    }

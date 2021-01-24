            ProcessStartInfo sigCheckProcess = new ProcessStartInfo();
            sigCheckProcess.FileName = "\\sigcheck64.exe";
            sigCheckProcess.Arguments = "-a -h -i -l -s " ;
            sigCheckProcess.RedirectStandardOutput = true;
            sigCheckProcess.UseShellExecute = false;
            sigCheckProcess.CreateNoWindow = true;
            using (Process exeProcess = Process.Start(sigCheckProcess))
            {
                exeProcess.WaitForExit();
                string line;
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter("output.txt")) // output txt file.
                {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(Path.Combine(@"c:\temp\", "test.txt")))  // replaces sigCheckProcess.StandardOutput
                    {
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            writer.WriteLine(line);
                        }
                    } 
                } 
            }
        }

                    Process Process = new Process();
                    Process.StartInfo.FileName = Pathdir + "\\test.exe";
                    Process.StartInfo.Arguments = "-a -h -s " + dir;
                    Process.StartInfo.RedirectStandardOutput = true;
                    Process.StartInfo.UseShellExecute = false;
                    Process.StartInfo.CreateNoWindow = true;
                    Process.Start();
                    using (StreamReader streamReader = Process.StandardOutput)
                    {
                        while (!streamReader.EndOfStream)
                        {
                            string line = streamReader.ReadLine();
                            Console.WriteLine(line);
                        }
                    }

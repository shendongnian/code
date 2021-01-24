                    Process process = new Process();
                    process.StartInfo.FileName = Pathdir + "\\test.exe";
                    process.StartInfo.Arguments = "-a -h -s " + dir;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    using (StreamReader streamReader = process.StandardOutput)
                    {
                        while (!streamReader.EndOfStream)
                        {
                            string line = streamReader.ReadLine();
                            Console.WriteLine(line);
                        }
                    }

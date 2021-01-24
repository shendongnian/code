            using (var process = new Process())
            {
                process.StartInfo.FileName = @"python.exe";
                process.StartInfo.Arguments = "-u test.py";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                while (!process.StandardOutput.EndOfStream)
                {
                    string line = process.StandardOutput.ReadLine();
                    Console.WriteLine(line);
                    // do something with line
                }
                process.WaitForExit();
                Console.Read();
            }

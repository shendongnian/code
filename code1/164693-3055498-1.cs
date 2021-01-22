            var process = new Process
            {
                StartInfo = new ProcessStartInfo("cmd.exe", "/C dir c:")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                }
            };
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine(output);

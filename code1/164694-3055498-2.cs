            var process = new Process
            {
                StartInfo = new ProcessStartInfo("cmd.exe")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                }
            };
            process.Start();
            // Discard "Microsoft windows all rights reserved etc.
            while (process.StandardOutput.ReadLine() != "") ;
            // Run command
            process.StandardInput.WriteLine("dir c:");
            // Skip command entered
            process.StandardOutput.ReadLine();
            // And exit
            process.StandardInput.WriteLine("exit");
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);

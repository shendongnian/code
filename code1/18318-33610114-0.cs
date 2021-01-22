            var process = new Process();
            process.StartInfo.FileName = "ping";
            process.StartInfo.Arguments = "google.com -t";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.OutputDataReceived += (sender, a) => Console.WriteLine(a.Data);
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();

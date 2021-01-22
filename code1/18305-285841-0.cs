    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.OutputDataReceived += (sender, args) => Console.WriteLine("received output: {0}", args.Data);
    process.Start();
    process.BeginOutputReadLine();

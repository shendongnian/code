    using( var process = new Process() )
    {
        process.StartInfo.FileName = "...";
        process.StartInfo.WorkingDirectory = "...";
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;
        process.Start();
    }

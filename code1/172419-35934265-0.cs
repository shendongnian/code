    string SourceFile = @"G:\SourceFolder\125.rar";
    string DestinationPath = @"G:\Destination\";
    System.Diagnostics.Process process = new System.Diagnostics.Process();
    process.StartInfo.FileName = @"G:\Software\WinRAR.exe";
    process.StartInfo.CreateNoWindow = true;
    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    process.EnableRaisingEvents = false;            
    process.StartInfo.Arguments = string.Format("x -o+ \"{0}\" \"{1}\"", SourceFile, DestinationPath);
    process.Start();

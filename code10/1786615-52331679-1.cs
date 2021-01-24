    using System.Diagnostics;
    ...
    Process process = new Process();
    process.StartInfo.FileName = xsdPath;
    process.StartInfo.Arguments = "/c " + File;
    process.StartInfo.WorkingDirectory = new FileInfo(File).DirectoryName;
    process.Start();
    //wait for exit if needed...
    process.WaitForExit();

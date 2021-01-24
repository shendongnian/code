    using System.Diagnostics;
    ...
    FileInfo fi = new FileInfo(ofd.FileName);
    Process process = new Process();
    process.StartInfo.FileName = xsdPath;
    process.StartInfo.Arguments = "/c " + fi.FullName;
    process.StartInfo.WorkingDirectory = fi.DirectoryName;
    process.Start();
    //wait for exit if needed...
    process.WaitForExit();

    UnRar("C:\\Download\\sampleextractfolder\\", filepath2);
    private static void UnRar(string WorkingDirectory, string filepath)
    {
        // Microsoft.Win32 and System.Diagnostics namespaces are imported
        //Dim objRegKey As RegistryKey
        RegistryKey objRegKey;
        objRegKey = Registry.ClassesRoot.OpenSubKey("WinRAR\\Shell\\Open\\Command");
        // Windows 7 Registry entry for WinRAR Open Command
        // Dim obj As Object = objRegKey.GetValue("");
        Object obj = objRegKey.GetValue("");
        //Dim objRarPath As String = obj.ToString()
        string objRarPath = obj.ToString();
        objRarPath = objRarPath.Substring(1, objRarPath.Length - 7);
        objRegKey.Close();
        //Dim objArguments As String
        string objArguments;
        // in the following format
        // " X G:\Downloads\samplefile.rar G:\Downloads\sampleextractfolder\"
        objArguments = " X " + " " + filepath + " " + " " + WorkingDirectory;
        // Dim objStartInfo As New ProcessStartInfo()
        ProcessStartInfo objStartInfo = new ProcessStartInfo();
        // Set the UseShellExecute property of StartInfo object to FALSE
        //Otherwise the we can get the following error message
        //The Process object must have the UseShellExecute property set to false in order to use environment variables.
        objStartInfo.UseShellExecute = false;
        objStartInfo.FileName = objRarPath;
        objStartInfo.Arguments = objArguments;
        objStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        objStartInfo.WorkingDirectory = WorkingDirectory + "\\";
        //   Dim objProcess As New Process()
        Process objProcess = new Process();
        objProcess.StartInfo = objStartInfo;
        objProcess.Start();
        objProcess.WaitForExit();
        try
        {
            FileInfo file = new FileInfo(filepath);
            file.Delete();
        }
        catch (FileNotFoundException e)
        {
            throw e;
        }
        
        
    }

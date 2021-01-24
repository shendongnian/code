    private static void StartVSCodeInFolder(string projectPath)
    {
        using (System.Diagnostics.Process process = new System.Diagnostics.Process())
        {
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                FileName = "C:/Program Files/Microsoft VS Code/Code.exe",
                Arguments = ".",
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = projectPath
            };
            process.StartInfo = startInfo;
            process.Start();
        }
    }

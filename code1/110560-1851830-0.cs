    public IProcess GetProcess(string pathToBuildTool, string cmdLineArguments, string workingDirectoryPath)
    {
        var psi = new ProcessStartInfo(pathToBuildTool, cmdLineArguments)
                      {
                          UseShellExecute = false,
                          RedirectStandardOutput = true,
                          RedirectStandardError = true,
                          WorkingDirectory = workingDirectoryPath,
                          Arguments = cmdLineArguments
                      };
    
        return new DiagnosticsProcess(Process.Start(psi));
    }

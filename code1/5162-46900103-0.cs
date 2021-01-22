    public static int setFileAssociation(string[] extensions, string fileType, string openCommandString) {
        int v = execute("cmd", "/c ftype " + fileType + "=" + openCommandString);
        foreach (string ext in extensions) {
            v = execute("cmd", "/c assoc " + ext + "=" + fileType);
            if (v != 0) return v;
        }
        return v;
    }
    public static int execute(string exeFilename, string arguments) {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.CreateNoWindow = false;
        startInfo.UseShellExecute = true;
        startInfo.FileName = exeFilename;
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
        startInfo.Arguments = arguments;
        try {
            using (Process exeProcess = Process.Start(startInfo)) {
                exeProcess.WaitForExit();
                return exeProcess.ExitCode;
            }
        } catch {
            return 1;
        }
    }

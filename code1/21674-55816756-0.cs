        public static void ShowFileInExplorer(FileInfo file) {
            StartProcess("explorer.exe", null, "/select, "+file.FullName.Quote());
        }
        public static Process StartProcess(FileInfo file, params string[] args) => StartProcess(file.FullName, file.DirectoryName, args);
        public static Process StartProcess(string file, string workDir = null, params string[] args) {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.FileName = file;
            proc.Arguments = string.Join(" ", args);
            Logger.Debug(proc.FileName, proc.Arguments); // Replace with your logging function
            if (workDir != null) {
                proc.WorkingDirectory = workDir;
                Logger.Debug("WorkingDirectory:", proc.WorkingDirectory); // Replace with your logging function
            }
            return Process.Start(proc);
        }

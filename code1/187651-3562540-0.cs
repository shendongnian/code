    public static void Main(string[] args) {
        try {
            DoNormalStartupStuff();
        }
        finally {
            foreach (var process in _runningProcesses) {
                process.Kill();
            }
        }
    }

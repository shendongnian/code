    public static class ProcessHelpers {
        public static bool IsRunning (string name) {
            return Process.GetProcessesByName(name).Length > 0 ? true : false;
        }
    }

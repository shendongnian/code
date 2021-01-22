        public static bool Is64BitSystem()
        {
            if (Directory.Exists(Environment.GetEnvironmentVariable("ProgramFiles(x86)"))) return true;
            else return false;
        }

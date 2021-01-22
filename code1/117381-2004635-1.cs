    public static bool IsInVisualStudio
    {
        get
        {
            bool inIDE = false;
            string[] args = System.Environment.GetCommandLineArgs();
            if (args != null && args.Length > 0)
            {
                string prgName = args[0].ToUpper();
                inIDE = prgName.EndsWith("VSHOST.EXE");
            }
            return inIDE;
        }
    }

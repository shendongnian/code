        public static void Test(string cmdLine, params string[] args)
        {
            string[] split = SplitCommandLine(cmdLine).ToArray();
            Debug.Assert(split.Length == args.Length);
            for (int n = 0; n < split.Length; n++)
                Debug.Assert(split[n] == args[n]);
        }

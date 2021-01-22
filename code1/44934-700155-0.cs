        delegate string AsyncMethodCaller(string fname);
        static void Main(string[] args)
        {
            string InputFilename = "testo.txt";
            AsyncMethodCaller caller = File.ReadAllText;
            IAsyncResult rslt = caller.BeginInvoke(InputFilename, null, null);
            // do other work ...
            string fileContents = caller.EndInvoke(rslt);
        }

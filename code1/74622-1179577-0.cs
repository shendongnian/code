        static void Main(string[] args)
        {
            bool doSomething = false;
            if (args.Length > 0 && args[0].Equals("doSomething"))
                doSomething = true;
            if (doSomething) Console.WriteLine("Commandline parameter called");
        }
    }

    static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        // Try to find the 'Title' argument
        var titleArg = args.FirstOrDefault(arg => arg.StartsWith("/Title:", StringComparison.OrdinalIgnoreCase));
        
        // Now strip off the beginning part of the argument
        titleArg = titleArg?.Replace("/Title:", "");
        // And now we can pass this to our form constructor
        Application.Run(new Form1(titleArg));
    }

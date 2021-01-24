    void Main()
    {
        var workDir = Path.Combine(Util.MyQueriesFolder, "nunit-work");
        var args = new string[]
        {
            "-noh",
            $"--work={workDir}",
        };
        RunUnitTests(args);
    }
    
    void RunUnitTests(string[] args, Assembly assembly = null)
    {
        Console.SetOut(new NoDisposeTextWriter(Console.Out));
        Console.SetError(new NoDisposeTextWriter(Console.Error));
        new AutoRun(assembly ?? Assembly.GetExecutingAssembly()).Execute(args);
    }
    
    class NoDisposeTextWriter : TextWriter
    {
        private readonly TextWriter writer;
        public NoDisposeTextWriter(TextWriter writer) => this.writer = writer;
    
        public override Encoding Encoding => writer.Encoding;
        public override IFormatProvider FormatProvider => writer.FormatProvider;
        public override void Write(char value) => writer.Write(value);
        public override void Flush() => writer.Flush();
        // forward all other overrides as necessary
        
        protected override void Dispose(bool disposing)
        {
            // no nothing
        }
    }

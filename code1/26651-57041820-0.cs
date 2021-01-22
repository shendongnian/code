    class ConsoleMirrorWriter : TextWriter
    {
        private readonly StreamWriter _writer;
        private readonly TextWriter _consoleOut;
        public ConsoleMirrorWriter(Stream stream)
        {
            _writer = new StreamWriter(stream);
            _consoleOut = Console.Out;
            Console.SetOut(this);
        }
        public override Encoding Encoding => _writer.Encoding;
        public override void Flush()
        {
            _writer.Flush();
            _consoleOut.Flush();
        }
        public override void Write(char value)
        {
            _writer.Write(value);
            _consoleOut.Write(value);
        }
        protected override void Dispose(bool disposing)
        {
            if (!disposing) return;
            _writer.Dispose();
            Console.SetOut(_consoleOut);
        }
    }

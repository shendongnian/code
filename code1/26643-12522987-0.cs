    public class CombinedWriter : StreamWriter
    {
        TextWriter console;
        public CombinedWriter(string path, bool append, Encoding encoding, int bufferSize, TextWriter console)
            :base(path, append, encoding, bufferSize)
        {
            this.console = console;
        }
        public override void Write(string value)
        {
            console.Write(value);
            base.Write(value);
        }
    }

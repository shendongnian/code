    public class CombinedWriter : StreamWriter
    {
        TextWriter console;
        public CombinedWriter(string path, bool append, Encoding encoding, int bufferSize, TextWriter console)
            :base(path, append, encoding, bufferSize)
        {
            this.console = console;
            base.AutoFlush = true; // thanks for @konoplinovich reminding
        }
        public override void Write(string value)
        {
            console.Write(value);
            base.Write(value);
        }
    }

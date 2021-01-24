    public class CustomJsonTextWriter : JsonTextWriter
    {
        public CustomJsonTextWriter(TextWriter writer) : base(writer)
        {
        }
        protected override void WriteIndent()
        {
            if (WriteState != WriteState.Array)
                base.WriteIndent();
            else
                WriteIndentSpace();
        }
    }

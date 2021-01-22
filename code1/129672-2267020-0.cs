    public class CustomStreamWriter : StreamWriter
    {
        public CustomStreamWriter(Stream stream)
            : base(stream)
        {}
        public override void Write(string value)
        {
            //Inspect the value and do something
            base.Write(value);
        }
    }

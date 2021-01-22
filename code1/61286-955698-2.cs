    public class Utf8StringWriter : StringWriter
    {
        public override Encoding
        {
             get { return Encoding.UTF8; }
        }
    }

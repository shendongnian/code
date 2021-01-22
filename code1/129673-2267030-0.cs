    public class Class1 : StreamWriter 
    {
        public Class1(Stream stream)
            : base(stream)
        {
            
        }
        public Class1(Stream stream, Encoding encoding)
            : base(stream, encoding)
        {
            
        }
        public Class1(Stream stream, Encoding encoding, int bufferSize)
            : base(stream, encoding, bufferSize)
        {
            
        }
        public Class1(string path)
            : base(path)
        {
            
        }
        public Class1(string path, bool append)
            : base(path, append)
        {
            
        }
        public Class1(string path, bool append, Encoding encoding)
            : base(path, append, encoding)
        {
            
        }
        public Class1(string path, bool append, Encoding encoding, int bufferSize)
            : base(path, append, encoding, bufferSize)
        {
            
        }
    
        public override void Write(string value)
        {
            base.Write(value);
        }
    }

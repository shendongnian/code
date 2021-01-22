    public class Props
    {
        private readonly string[] data = new string[2];
        
        public string Foo {
            get { return data[0]; }
        }
        public string Bar {
            get { return data[1]; }
        }
    
        public IList<string> ModifyValueButNoInsertsList { get { return data;} }
    }

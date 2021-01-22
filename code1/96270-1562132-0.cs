    class TokenReader : IDisposable
    {
        private TextReader _reader;        
        Queue<string> tokens = new Queue<string>();
    
        public TokenReader(string filename)
        {
            _reader = File.OpenText(filename);            
        }
    
        public void Dispose()
        {
            if (_reader != null)
                _reader.Dispose();
        }
    
        public string NextString()
        {
            if (tokens.Count < 1)
            {
                string line = _reader.ReadLine();
    
                if (line == null)
                    return null;
    
                string[] toks = line.Split(null);
    
                tokens = new Queue<string>(toks);
            }
    
            string r = tokens.Dequeue();
            System.Diagnostics.Debug.Print(">{0}<", r);
            return r;
        }
    
        public double NextDouble()
        {            
            string s = NextString();
            return double.Parse(s);
        }
    
    }

    public class ReadTheFile : IDisposable
    {
        private int _lineCounter = 0;
        private string _lineOfText;
        private StreamReader _sr = null;
    
        public ReadTheFile Open(string path)
        {
            sr = new StreamReader(path);
            return this;
        }
    
        public void Read()
        {
            if(_sr == null) return;
            while ((_lineOfText = _sr.ReadLine()) != null) {
                Console.WriteLine(_lineOfText);
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) 
            {
                if(_sr != null) 
                {
                   _sr.Close();
                   _sr = null;
                }
            }
        }   
    }

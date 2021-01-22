    class TextWriter : System.IDisposable
    {
        private StreamWriter writer = null;
        
        public TextWriter(string fileName)
        {
            this.writer = StreamWriter(fileName);
        }
        ~TextWriter() // destructor
        {
            this.Dispose(false); // false: I am not disposing
        }
        public void Dispose()
        {
            this.Dispose(true); // true: I am disposing
            GC.SuppressFinalize(this);
            // tell the garbage collector that this object doesn't need to be
            // finalized (destructed) anymore
         }
         
         private void Dispose(bool dispose)
         {
             if (this.writer != null)
             {
                 this.writer.Dispose();
                 this.writer = null;
             }
         }
         
         ...
     }

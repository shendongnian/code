    public sealed class Foo : IDisposable
    {
        private StreamWriter _Writer;
        public Foo(string path)
        {
                FileStream fileWrite = File.Open (path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
                try { 
                    _Writer = new StreamWriter (fileWrite, new ASCIIEncoding());
                } catch {
                    fileWrite.Dispose();
                    throw;
                }
        }
        public void Dispose()
        {
             _Writer.Dispose();
        }
    }

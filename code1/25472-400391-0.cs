    using System;
    using System.IO;
    sealed class TempFile : IDisposable
    {
        string path;
        public TempFile() : this(System.IO.Path.GetTempFileName()) { }
    
        public TempFile(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("path");
            this.path = path;
        }
        public string Path
        {
            get
            {
                if (path == null) throw new ObjectDisposedException(GetType().Name);
                return path;
            }
        }
        ~TempFile() { Dispose(false); }
        public void Dispose() { Dispose(true); }
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
                if (path != null)
                {
                    try { File.Delete(path); }
                    catch { } // best effort
                    path = null;
                }
            }
        }
    }
    static class Program
    {
        static void Main()
        {
            string path;
            using (var tmp = new TempFile())
            {
                path = tmp.Path;
                Console.WriteLine(File.Exists(path));
            }
            Console.WriteLine(File.Exists(path));
        }
    }

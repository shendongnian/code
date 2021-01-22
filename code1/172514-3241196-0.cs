    public class TemporaryFile : IDisposable
    {
        private bool _isDisposed;
        public bool Keep { get; set; }
        public string Path { get; private set; }
        
        public TemporaryFile() : this(false)
        {
        }
        public TemporaryFile(bool shortLived)
        {
            this.Path = CreateTemporaryFile(shortLived);
        }
        ~TemporaryFile()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        } 
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
                if (!this.Keep)
                {
                    TryDelete();   
                }
            }
        }
        private void TryDelete()
        {
            try
            {
                File.Delete(this.Path);
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
        public static string CreateTemporaryFile(bool shortLived)
        {
            string temporaryFile = System.IO.Path.GetTempFileName();
            if (shortLived)
            { 
                // Set the temporary attribute, meaning the file will live 
                // in memory and will not be written to disk 
                //
                File.SetAttributes(temporaryFile, 
                    File.GetAttributes(temporaryFile) | FileAttributes.Temporary);
            }
            return temporaryFile;
        }
    }

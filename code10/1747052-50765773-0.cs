    class MyCryptoStream : IDisposable
    {
        private FileStream fileStream = null;
        private AesCryptoServiceProvider aes = null;
        public CryptoStream cryptoStream = null;
        public enum Mode
        {
            Write,
            Read
        }
        public MyCryptoStream(string filepath, Mode mode, byte[] key, byte[] iv = null)
        {
            if(mode == Mode.Write)
            {
                fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Write);
                fileStream.Write(iv, 0, 16);
                aes = new AesCryptoServiceProvider() { Key = key, IV = iv };
                cryptoStream = new CryptoStream(fileStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
            }
            else
            {
                iv = new byte[16];
                fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                fileStream.Read(iv, 0, 16);
                aes = new AesCryptoServiceProvider() { Key = key, IV = iv };
                cryptoStream = new CryptoStream(fileStream, aes.CreateDecryptor(), CryptoStreamMode.Read);
            }
        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (cryptoStream != null)
                    {
                        cryptoStream.Dispose();
                    }
                    if (aes != null)
                    {
                        aes.Dispose();
                    }
                    if (fileStream != null)
                    {
                        fileStream.Dispose();
                    }
                }
                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                disposedValue = true;
            }
        }
        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UsingReduction() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

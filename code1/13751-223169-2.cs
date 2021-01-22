    public class BinaryReader : IDisposable
    {
        public virtual void Close()
        {
           this.Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
           if (disposing)
           {
              Stream stream = this.m_stream;
              this.m_stream = null;
              if (stream != null)
              {
                 stream.Close();
              }
           }
           this.m_stream = null;
           this.m_buffer = null;
           this.m_decoder = null;
           this.m_charBytes = null;
           this.m_singleChar = null;
           this.m_charBuffer = null;
       }
       void IDisposable.Dispose()
       {
          this.Dispose(true);
       }
    }

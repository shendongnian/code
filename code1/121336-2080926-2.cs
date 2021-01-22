    class SynchronizedReader {
    
      private Stream _stream;
      private object _sync;
    
      public SynchronizedReader(Stream s) {
        _stream = s;
        _sync = new object();
      }
    
      public string ReadLine() {
        lock (_sync) {
          StringBuilder line = new StringBuilder();
          while (true) {
            if (_stream == null) return null;
            int c = _stream.ReadByte();
            switch (c) {
              case 10: break;
              case 13:
              case -1: return line.ToString();
              default: line.Append((char)c);
            }
          }
        }
      }
    
      public void Close() {
        lock (_sync) {
          _stream.Close();
          _stream = null;
        }
      }
    
    }

    using System;
    using System.IO;
    using System.Threading;
    
    namespace StreamReaderTest {
    
      class SynchronizedReader {
    
        private StreamReader _reader;
        private object _sync;
    
        public SynchronizedReader(Stream s) {
          _reader = new StreamReader(s);
          _sync = new object();
        }
    
        public string ReadLine() {
          lock (_sync) {
            if (_reader == null) return null;
            return _reader.ReadLine();
          }
        }
    
        public void Close() {
          lock (_sync) {
            _reader.Close();
            _reader = null;
          }
        }
    
      }
    
      class Program {
    
        static void Main(string[] args) {
          new Program();
        }
    
        private SynchronizedReader reader;
    
        public Program() {
          reader = new SynchronizedReader(Console.OpenStandardInput());
    
          new Thread(new ThreadStart(this.Close)).Start();
    
          string line;
          while ((line = reader.ReadLine()) != null) {
             Console.WriteLine(line);
          }
        }
    
        public void Close() {
          Thread.Sleep(2000);
          reader.Close();
          Console.WriteLine("Stream Closed");
        }
      }
    
    }

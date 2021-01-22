      class Logger : IDisposable {
        private StreamWriter sw;
        public void Dispose() {
          sw.Dispose();   // Or sw.Close(), same thing
        }
        // etc...
      }

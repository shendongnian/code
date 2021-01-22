    using System;
    using System.Threading;
    namespace VolatileTest
    {
      class VolatileTest 
      {
        private volatile int _volatileInt;
        public void Run() {
          new Thread(delegate() { Thread.Sleep(500); _volatileInt = 1; }).Start();
          while ( _volatileInt != 1 ) 
            ; // Do nothing
          Console.WriteLine("_volatileInt="+_volatileInt);
        }
      }
      class NormalTest 
      {
        private int _normalInt;
        public void Run() {
          new Thread(delegate() { Thread.Sleep(500); _normalInt = 1; }).Start();
          // NOTE: Program hangs here in Release mode only (not Debug mode).
          // See: http://stackoverflow.com/questions/133270/illustrating-usage-of-the-volatile-keyword-in-c-sharp
          // for an explanation of why. The short answer is because the
          // compiler optimisation caches _normalInt on a register, so
          // it never re-reads the value of the _normalInt variable, so
          // it never sees the modified value. Ergo: while ( true )!!!!
          while ( _normalInt != 1 ) 
            ; // Do nothing
          Console.WriteLine("_normalInt="+_normalInt);
        }
      }
      class Program
      {
        static void Main() {
    #if DEBUG
          Console.WriteLine("You must run this program in Release mode to reproduce the problem!");
    #endif
          new VolatileTest().Run();
          Console.WriteLine("This program will now hang!");
          new NormalTest().Run();
        }
      }
    }

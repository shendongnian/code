    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.IO;
    using System.Diagnostics;
    
    namespace MiniDumpTest
    {
    class Program {
    
        static void Main(string[] args) {
          AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);        
    
          Console.WriteLine("started");
    
          try {
            Console.WriteLine(MyFunc());
          } finally {
            Console.WriteLine("finished");
            Console.ReadLine();
          }
        }
    
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            Console.WriteLine("CurrentDomain_UnhandledException");
    
            DbgHelpNet.MiniDumpWriteDump.WriteDump(@"c:\temp\MyDump.dmp");
    
            Console.WriteLine("MiniDump written");
        }
    
        static int MyFunc() {
          int i = 0;
          ++i;
          if (i == 1) {
            throw new ApplicationException("bla");
          }
    
          return i;
        }
      }
    }

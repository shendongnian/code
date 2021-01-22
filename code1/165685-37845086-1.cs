    using System;
    using System.Diagnostics;
    using static System.Console;
    using System.Threading;
    
    class Program {
    
        static void Main(string[] args) {
    
            WriteLine("About to start process...");
    
            //Toggle which method is commented out:
            //StartWithPath();  //Blocking
            //StartWithInfo();  //Blocking
            StartInNewThread(); //Not blocking
    
            WriteLine("Process started!");
            Read();
        }
    
        static void StartWithPath() {
            Process.Start(TestPath);
        }
    
        static void StartWithInfo() {
            var p = new Process { StartInfo = new ProcessStartInfo(TestPath) };
            p.Start();
        }
    
        static void StartInNewThread() {
            var t = new Thread(() => StartWithPath());
            t.Start();
        }
    
        static string TestPath =
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
            "\\test.xlsx";
    }

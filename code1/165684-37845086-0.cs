    using System;
    using System.Diagnostics;
    using static System.Console;
    
    namespace ConsoleApplication1 {
        class Program {
    
            static void Main(string[] args) {
                
                WriteLine("About to start process...");
    
                //Toggle which method is commented out:
                //StartWithPath();
                StartWithStartInfo();
    
                WriteLine("Process started!");
                Read();
            }
    
            static void StartWithPath() {
                Process.Start(TestPath);
            }
    
            static void StartWithStartInfo() {
                var p = new Process { StartInfo = new ProcessStartInfo(TestPath) };
                p.Start();
            }
    
            static string TestPath = 
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + 
                "\\test.xlsx";
        }
    }

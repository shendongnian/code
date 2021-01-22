    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace ConsoleApplication9 {
        class Program {
    
            [STAThread]
            static void Main(string[] args) {
    
                if (args.Length > 0 && args[0] == "console") {
                    Console.WriteLine("Hello world!");
                    Console.ReadLine();
                }
                else {
                    Application.EnableVisualStyles(); 
                    Application.SetCompatibleTextRenderingDefault(false); 
                    Application.Run(new Form1());
                }
            }
        }
    }

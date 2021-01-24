    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Linq;
    
    namespace ConsoleWindow
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (args.Contains("-w"))
                {
                    Form1 f1 = new Form1();
                    f1.ShowDialog();
                }
                Console.ReadKey();
            }
        }
    }

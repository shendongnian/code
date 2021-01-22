    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace PEFixer
    {
        static class Program
        {
            [DllImport("kernel32.dll")]
            private static extern bool AttachConsole(int dwProcessId);
    
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static int Main(string[] args)
            {
                if (args.Length > 0)
                {
                    AttachConsole(-1);
                    return Form1.doTransformCmdLine(args);
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
                return 0;
            }
        }
    }

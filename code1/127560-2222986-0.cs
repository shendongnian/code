    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    namespace test
    {
        class Program
        {
            [DllImport("COMCTL32")]
            private static extern int InitCommonControls(int nExitCode);
            static void Main(string[] args)
            {
                InitCommonControls(0);
                string file = "C:\\ProblemFile.dll";
                FileVersionInfo version = FileVersionInfo.GetVersionInfo(file);
                string fileName = version.FileName;
                string fileVersion = version.FileVersion;
                Console.WriteLine(string.Format("{0} : {1}", fileName, fileVersion));
            }
        }
    }

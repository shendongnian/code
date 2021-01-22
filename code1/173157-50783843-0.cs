    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    
    namespace RemoteProcessDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                string strComputerName = "";
                string strProcString = "";
                try
                {
                    strComputerName = args[0];
                    Process.Start("wmic", "/node:" + strComputerName + " process call create notepad.exe");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    using System;
    using System.Diagnostics;
    using Microsoft.VisualBasic;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                Process[] proc = Process.GetProcessesByName("notepad");
                Interaction.AppActivate(proc[0].MainWindowTitle);
            }
        }
    }

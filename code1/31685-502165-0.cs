    using System;
    using System.Diagnostics;
    namespace csharp_station.howto
    {
        /// <summary>
        /// Demonstrates how to start another program from C#
        /// </summary>
        class ProcessStart
        {
            static void Main(string[] args)
            {
                Process notePad = new Process();
    
                notePad.StartInfo.FileName   = "notepad.exe";
                notePad.StartInfo.Arguments = "ProcessStart.cs";
    
                notePad.Start();
            }
        }
    }

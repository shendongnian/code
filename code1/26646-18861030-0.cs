    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace RedirectOutput
    {
        public class CombinedWriter  : StreamWriter
        {
            TextWriter console;
            public CombinedWriter(string path, bool append, TextWriter consoleout)
                : base(path, append)
            {
                this.console = consoleout;
                base.AutoFlush = true;
            }
            public override void Write(string value)
            {
                console.Write(value);
                //base.Write(value);//do not log writes without line ends as these are only for console display
            }
            public override void WriteLine()
            {
                console.WriteLine();
                //base.WriteLine();//do not log empty writes as these are only for advancing console display
            }
            public override void WriteLine(string value)
            {
                console.WriteLine(value);
                if (value != "")
                {
                    base.WriteLine(value);
                }
            }
            public new void Dispose()
            {
                base.Dispose();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                CombinedWriter cw = new CombinedWriter("combined.log", false, Console.Out);
                Console.SetOut(cw);
                Console.WriteLine("Line 1");
                Console.WriteLine();
                Console.WriteLine("Line 2");
                Console.WriteLine("");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("Waiting " + i.ToString());
                    Console.CursorLeft = 0;
                }
                Console.WriteLine();
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("Waiting " + i.ToString());
                }
                Console.WriteLine();
                Console.WriteLine("Line 3");
                cw.Dispose();
            }
        }
    }

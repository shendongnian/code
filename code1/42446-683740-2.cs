    using System;
    
    namespace MyNamespace
    {
        static class Program
        {
            [STAThread]
            static int Main(string[] args)
            {
                return MainEntry.DoMain(args, true);
            }
        }
    }

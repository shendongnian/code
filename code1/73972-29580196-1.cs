    using ExpectNet;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ExampleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine("ExampleApp");
                    Session spawn = Expect.Spawn(new ProcessSpawnable("cmd.exe"));
                    spawn.Expect("c:", s => Console.WriteLine("got: " + s));
                }
        }
    }

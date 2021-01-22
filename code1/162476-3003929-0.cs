    using System;
    using System.Threading;
    
    namespace Treading
    {
        class Program
        {
            static void Main(string[] args)
            {
                Thread noiseMaker = new Thread(Noisy);
                noiseMaker.Start();
            }
    
            public static void Noisy()
            {
                while(true)
                    Console.WriteLine("Hello!");
            }
        }
    }

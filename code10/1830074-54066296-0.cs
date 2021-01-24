    using System;
    using System.Threading;
    namespace ConsoleApp1
    {
        class Program
        {
            static void BusyDelay()
            {
                long i = 10000000000;
                while (i-- > 0) ;
            }
            static void Main(string[] args)
            {
                /* use "1" intead of "ProcessorCount" for single thread insted */
                for (int i = 0; i < Environment.ProcessorCount ; i++)
                {
                    new Thread(BusyDelay).Start();                
                }                        
            }
        }
    }

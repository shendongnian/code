    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace OOM_32_forced
    {
        class Program
        {
            static void Main(string[] args)
            {
                //each short is 2 byte big, Int32.MaxValue is 2^31.
                //So this will require a bit above 2^32 byte, or 2 GiB
                short[] Array = new short[Int32.MaxValue];
    
                /*need to actually access that array
                Otherwise JIT compiler and optimisations will just skip
                the array definition and creation */
                foreach (short value in Array)
                    Console.WriteLine(value);
            }
        }
    }

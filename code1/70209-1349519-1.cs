    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.ConstrainedExecution;
    
    class Program {
        static bool cerWorked;
    
        static void Main( string[] args ) {
            try {
                cerWorked = true;
                MyFn();
            }
            catch( OutOfMemoryException ) {
                Console.WriteLine( cerWorked );
            }
            Console.ReadLine();
        }
    
        unsafe struct Big {
            public fixed byte Bytes[int.MaxValue];
        }
    
        //results depends on the existance of this attribute
        [ReliabilityContract( Consistency.WillNotCorruptState, Cer.Success )] 
        unsafe static void StackOverflow() {
            Big big;
            big.Bytes[ int.MaxValue - 1 ] = 1;
        }
    
        static void MyFn() {
            RuntimeHelpers.PrepareConstrainedRegions();
            try {
                cerWorked = false;
            }
            finally {
                StackOverflow();
            }
        }
    }

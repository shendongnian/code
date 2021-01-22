        using System;
    
        internal class Program
        {
            private static void Main(string[] args)
            {
    #if NETFX_451
                Console.WriteLine("NET_451 was set");
    #endif
    
    #if NETFX_45
                Console.WriteLine("NET_45 was set");
    #endif
    
    #if NETFX_40
                Console.WriteLine("NET_40 was set");
    #endif
    #if NETFX_35
                Console.WriteLine("NETFX_35 was set");
    #endif
    
    #if NETFX_30
                Console.WriteLine("NETFX_30 was set");
    #endif
    
    #if NETFX_20
                 Console.WriteLine("NETFX_20 was set");
    #else
               The Version specific symbols were not set correctly!
    #endif
    
    #if DEBUG
                Console.WriteLine("DEBUG was set");
    #endif
    
    #if MySymbol
                Console.WriteLine("MySymbol was set");
    #endif
                Console.ReadKey();
            }
        }
    }
    

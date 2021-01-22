    Console.WriteLine("Current ProcessorAffinity: {0}", 
                      Process.GetCurrentProcess().ProcessorAffinity);
    Process.GetCurrentProcess().ProcessorAffinity = (System.IntPtr)2;
    Console.WriteLine("Current ProcessorAffinity: {0}", 
                      Process.GetCurrentProcess().ProcessorAffinity);

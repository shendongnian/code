    using System;
    
    namespace GCMemTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                System.GC.Collect();
    
                long startBytes = System.GC.GetTotalMemory(true);
            	
                {
                    string[] strings = new string[2000000];
                    for (int i = 0; i < 2000000; i++)
                    {
                        strings[i] = "blabla" + i;
                    }
                    strings = null;
                }
    
    	        System.GC.Collect();
    
                long endBytes = System.GC.GetTotalMemory(true);
    
                double kbStart = (double)(startBytes) / 1024.0;
    	        double kbEnd = (double)(endBytes) / 1024.0;
    
    	        System.Console.WriteLine("Leaked " + (kbEnd - kbStart) + "KB.");
                System.Console.ReadKey();
            }
        }
    }

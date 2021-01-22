    using System;
    
    namespace unsafeTest
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                unsafe 
                {		
                	int x = 0;
                	int y = 0;
                	int z = 0;
                	bar(&x, &y, &z);
                	Console.WriteLine(x);
                	Console.WriteLine(y);
                	Console.WriteLine(z);
                }
            }
        	
            unsafe static void bar(params int *[] pInts)
            {
            	int i = 0;
            	foreach (var pInt in pInts)
            	{
            		*pInt = i++;
            	}
            }
        }
    }

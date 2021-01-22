    using System;
    
    namespace Strings
    {
        class Program
        {
            static void Main(string[] args)
            {
    
    /*          decimal pie = 1; 
                decimal e = -1;
    */
                var stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start(); //added this nice stopwatch start routine 
        
      //leibniz formula in C# - code written completely by Todd Mandell 2014
    /*
                for (decimal f = (e += 2); f < 1000001; f++)
                {
                     e += 2;
                     pie -= 1 / e;
                     e += 2;
                     pie += 1 / e;
                     Console.WriteLine(pie * 4);
                }
    
                     decimal finalDisplayString = (pie * 4);
                     Console.WriteLine("pie = {0}", finalDisplayString);
                     Console.WriteLine("Accuracy resulting from approximately {0} steps", e/4); 
    */
    
    // Nilakantha formula - code written completely by Todd Mandell 2014
    // π = 3 + 4/(2*3*4) - 4/(4*5*6) + 4/(6*7*8) - 4/(8*9*10) + 4/(10*11*12) - (4/(12*13*14) etc
    
                decimal pie = 0;
                decimal a = 2;
                decimal b = 3;
                decimal c = 4;
                decimal e = 1;
    
                for (decimal f = (e += 1); f < 100000; f++) 
                // Increase f where "f < 100000" to increase number of steps
                {
    
                    pie += 4 / (a * b * c);
                    
                    a += 2;
                    b += 2;
                    c += 2;
                    
                    pie -= 4 / (a * b * c);
    
                    a += 2;
                    b += 2;
                    c += 2;
    
                    e += 1;
                }
                
                decimal finalDisplayString = (pie + 3);
                Console.WriteLine("pie = {0}", finalDisplayString);
                Console.WriteLine("Accuracy resulting from {0} steps", e); 
    
                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                Console.WriteLine("Calc Time {0}", ts); 
    
                Console.ReadLine();
                     
             }
         }
     }

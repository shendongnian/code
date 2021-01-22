    using System;
    
    namespace LogisticFunction
    {
        class Program
        {
            static void Main(string[] args)
            {
                Double minAlt = 5.0;
                Double maxAlt = 95.0;
    
                Int32 numberSteps = 60;
    
                // Keep maxAlt and numberSteps small if you don't want a giant console window.
                Console.SetWindowSize((Int32)maxAlt + 12, numberSteps + 1);
    
                // Positive values produce ascending functions
                // Negative values produce descending functions
                // Values with smaller magnitude produce more linear functions
                // Values with larger magnitude produce more step like functions
                // Zero causes an error
                // Try for example +1.0, +6.0, +10.0 and -1.0, -6.0, -10.0
                Double boundary = +6.0;
    
                for (Int32 step = 0; step < numberSteps; step++)
                {
                    Double t = -boundary + 2.0 * boundary * step / (numberSteps - 1);
                    Double correction = 1.0 / (1.0 + Math.Exp(Math.Abs(boundary)));
                    Double value = 1.0 / (1.0 + Math.Exp(-t));
                    Double correctedValue = (value - correction) / (1.0 - 2.0 * correction);
                    Double curAlt = correctedValue * (maxAlt - minAlt) + minAlt;
    
                    Console.WriteLine(String.Format("{0, 10:N4} {1}", curAlt, new String('#', (Int32)Math.Round(curAlt))));
                }
    
                Console.ReadLine();
            }
        }
    }

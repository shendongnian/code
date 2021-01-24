    using System.IO;
    using System;
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine(GetNumberOfApplesEaten(100,5));
        }
        
        public static int GetNumberOfApplesEaten(int X, int Y)
        {
            int result = 0;
            
            // while we can eat 'Y' apples
            while(X >= Y)
            {
                // we eat & count those apples
                result += Y;
                X -= Y;
                // we add an extra apple
                X++;
            }
            // we eat what's left
            result += X;
            
            return result;
        }
    }

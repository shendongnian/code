    using System.IO;
    using System;
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine(GetNumberOfApplesEaten(100,5));
        }
        
        public static int GetNumberOfApplesEaten(int start, int step)
        {
            int result = 0;
            
            while(start > step)
            {
                result += step;
                start -= step;
                start++;
            }
            result += start;
            
            return result;
        }
    }

    using System;
    
    namespace TestRandom23874
    {
        class Program
        {
            static void Main(string[] args)
            {
                Random rng = new Random();
                Console.WriteLine("the random number is: {0}", 
                    MathHelpers.GetRandomNumber(rng, 1, 10));
                Console.WriteLine("the random number is: {0}", 
                    MathHelpers.GetRandomNumber(rng, 1, 10));
                Console.WriteLine("the random number is: {0}", 
                    MathHelpers.GetRandomNumber(rng, 1, 10));
                Console.WriteLine("the random number is: {0}", 
                    MathHelpers.GetRandomNumber(rng, 1, 10));
                Console.WriteLine("the random number is: {0}", 
                    MathHelpers.GetRandomNumber(rng, 1, 10));
            }
        }
    
        public class MathHelpers
        {
            public static int GetRandomNumber(Random random, int min, int max)
            {
                return random.Next(min, max);
            }
        }
    }

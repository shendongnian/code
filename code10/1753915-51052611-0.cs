    namespace FizzBuzz
    {
        public class Class1
        {
            public static void Main(string[] args)
            {
                    int fizzCount = 0;
                    int buzzCount = 0;
                    int fizzbuzzCount = 0;
                    for (int i = 1; i <= 1000; i++)
                    {
                        //Declaration of Fizz and Buzz as Boolean
                        bool fizz = i % 3 == 0;
                        bool buzz = i % 5 == 0;
                        //Fizzbuzz declared to be conditional if its both
                        bool fizzbuzz = fizz && buzz;
    
                        if (fizzbuzz)
                        {
                           fizzbuzzCount++;
                           Console.WriteLine("FizzBuzz");
    
                        }
                        else if (fizz)
                        {
                            fizzCount++;
                            Console.WriteLine("Fizz");
                        }
                        else if (buzz)
                        {
                            buzzCount++;
                            Console.WriteLine("Buzz");
                        }
                        else
                            Console.WriteLine(i);
                        }
                    }
                    Console.WriteLine("Fizz count" + fizzCount.ToString();
                    Console.WriteLine("Buzz count" + buzzCount.ToString();
                    Console.WriteLine("FizzBuzz count" + fizzbuzzCount.ToString();
                }
            }
        }

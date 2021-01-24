    using static System.Math;
    using System.Linq;
    using static System.Console;
    namespace ConsoleApp4
    {
        class Program
        {
            static void Main(string[] args)
            {
                WriteLine($"The total sum of the array is: { new[] { 1, 2, 3, -1, 0 }.Sum(x => Max(0, x))}");
                ReadKey();
            }
        }
    }

        class Program
        {
         static void Main(string[] args)
         {
             double radius = 6;
             double areaOfCircle = 0;
             areaOfCircle = StaticExample.Pi * radius * radius;
             Console.WriteLine("Area = "+areaOfCircle);
             Console.ReadKey();
         }
      }

    using System;
     
    namespace out_parameter
    {
      class Program
       {
         //Accept two input parameter and returns two out value
         public static void rect(int len, int width, out int area, out int perimeter)
          {
            area = len * width;
            perimeter = 2 * (len + width);
          }
         static void Main(string[] args)
          {
            int area, perimeter;
            // passing two parameter and getting two returning value
            Program.rect(5, 4, out area, out perimeter);
            Console.WriteLine("Area of Rectangle is {0}\t",area);
            Console.WriteLine("Perimeter of Rectangle is {0}\t", perimeter);
            Console.ReadLine();
          }
       }
    }

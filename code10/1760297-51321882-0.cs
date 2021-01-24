    using System;
    public class Program
    {
    
    public static int Compute(int i)
    {
        i = int.Parse(Console.ReadLine());
        for (int n = 0; n <= i; n++)
        {
            if (n % 2 == 0)
            {
                Console.WriteLine(n);
            }
        }
        return i;
    }
    
    public static void Main()
    {
    
        Console.WriteLine("Enter the number: ");
        int i=Convert.ToInt32(Console.ReadLine());// Define i
        Compute(i);
    
        Console.WriteLine(Compute(i));
    }
    }

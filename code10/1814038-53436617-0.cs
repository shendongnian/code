    using System;
    public class Exercise6
    {
        public static void Main()
        {
    
        int x,y,z;
    
        Console.Write("First number:");
        x = Convert.ToInt32(Console.ReadLine());
    
        Console.Write("\nSecond number:");
        y = Convert.ToInt32(Console.ReadLine());
    
        Console.Write("\nThird number:");
        z = Convert.ToInt32(Console.ReadLine());
    
        int res1 = ((x + y) * z);
        Console.WriteLine(res1);
        Console.ReadLine();
    }

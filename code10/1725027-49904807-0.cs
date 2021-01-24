    double num = 0.00000123456789;
    
    Console.WriteLine("original :");
    Console.WriteLine(num.ToString());
    Console.WriteLine(num.ToString("F6"));
    Console.WriteLine(num.ToString("F10"));
    Console.WriteLine(num.ToString("F14"));
    Console.WriteLine("rounded to 6");
    double rounded6 = Math.Round(num, 6);
    Console.WriteLine(rounded6.ToString());
    Console.WriteLine(rounded6.ToString("F6"));
    Console.WriteLine(rounded6.ToString("F10"));
    Console.WriteLine(rounded6.ToString("F14"));
    
    Console.WriteLine("rounded to 10");
    double rounded10 = Math.Round(num, 10);
    Console.WriteLine(rounded10.ToString());
    Console.WriteLine(rounded10.ToString("F6"));
    Console.WriteLine(rounded10.ToString("F10"));
    Console.WriteLine(rounded10.ToString("F14"));

    
    try
    {
        Console.Write("write your number : ");
        Console.WriteLine("Your number is : " + int.Parse(Console.ReadLine()));
    }
    catch (Exception x)
    {
        Console.WriteLine(x.Message);
    }
    Console.ReadLine();
